using UnityEngine;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Substrate.NetApi.Model.Extrinsics;
using VaraExt = Substrate.Vara.NET.NetApiExt.Generated;
using System.Collections.Generic;

public static class QueryService
{
    private static VaraExt.SubstrateClientExt _client;
    private static string _currentUrl;

    public static async Task<object> QueryStateAsync(
        string url,
        string idl,
        string service,
        string query,
        string type,
        string actorId,
        string programId,
        long gasLimit,
        int value,
        byte[] payload = null)
    {
        await EnsureClientConnectedAsync(url);

        if (!_client.IsConnected)
        {
            Debug.LogError("Client is not connected.");
            return null;
        }

        byte[] messagePayload = CreateMessagePayload(service, query, payload);
        RpcResult rpcResult = await InvokeGearCalculateReply(actorId, programId, messagePayload, gasLimit, value);
        byte[] queryBytes = ExtractRelevantBytes(rpcResult.Payload.ConvertAll(b => (byte)b).ToArray(), service, query);
        object decodedResult = DecodeQueryResult(queryBytes, type, query);

        return decodedResult ?? queryBytes;
    }

    private static async Task EnsureClientConnectedAsync(string url)
    {
        if (_client == null || _currentUrl != url)
        {
            _currentUrl = url;
            _client = new VaraExt.SubstrateClientExt(new Uri(url), ChargeTransactionPayment.Default());
            await _client.ConnectAsync();
        }
    }

    private static byte[] CreateMessagePayload(string service, string function, byte[] payload)
    {
        byte[] scaleBytes = EncodeToScale(service, function);

        return payload == null ? scaleBytes : ConcatenateArrays(scaleBytes, payload);
    }

    private static byte[] ConcatenateArrays(byte[] first, byte[] second)
    {
        byte[] result = new byte[first.Length + second.Length];
        Buffer.BlockCopy(first, 0, result, 0, first.Length);
        Buffer.BlockCopy(second, 0, result, first.Length, second.Length);
        return result;
    }

    private static byte[] EncodeToScale(string service, string query)
    {
        byte[] serviceBytes = Encoding.ASCII.GetBytes(service);
        byte[] queryBytes = Encoding.ASCII.GetBytes(query);

        return ConcatenateArrays(
            ConcatenateArrays(EncodeCompactInteger(serviceBytes.Length), serviceBytes),
            ConcatenateArrays(EncodeCompactInteger(queryBytes.Length), queryBytes)
        );
    }

    private static byte[] EncodeCompactInteger(int value)
    {
        if (value <= 0x3F)
        {
            return new byte[] { (byte)(value << 2) };
        }
        if (value <= 0x3FFF)
        {
            return new byte[] { (byte)((value << 2) | 0x01), (byte)(value >> 6) };
        }
        if (value <= 0x3FFFFFFF)
        {
            return new byte[] {
                (byte)((value << 2) | 0x02),
                (byte)(value >> 6),
                (byte)(value >> 14),
                (byte)(value >> 22)
            };
        }
        throw new ArgumentOutOfRangeException(nameof(value), "Value too large to be encoded as compact integer");
    }

    private static async Task<RpcResult> InvokeGearCalculateReply(
        string actorId,
        string programId,
        byte[] messagePayload,
        long gasLimit,
        int value)
    {
        return await _client.InvokeAsync<RpcResult>(
            "gear_calculateReplyForHandle",
            new object[] {
                actorId,
                programId,
                ConvertToHex(messagePayload),
                gasLimit,
                value,
                null
            },
            CancellationToken.None
        );
    }

    private static string ConvertToHex(byte[] data)
    {
        return "0x" + BitConverter.ToString(data).Replace("-", "").ToLower();
    }

    private static byte[] ExtractRelevantBytes(byte[] stateBytes, string service, string query)
    {
        int lastPrefixIndex = GetLastPrefixIndex(stateBytes, service, query);

        if (lastPrefixIndex < stateBytes.Length)
        {
            byte[] relevantBytes = new byte[stateBytes.Length - lastPrefixIndex];
            Array.Copy(stateBytes, lastPrefixIndex, relevantBytes, 0, relevantBytes.Length);
            return relevantBytes;
        }

        return stateBytes;
    }

    private static int GetLastPrefixIndex(byte[] stateBytes, string service, string query)
    {
        byte[] servicePrefix = Encoding.UTF8.GetBytes(service);
        byte[] queryPrefix = Encoding.UTF8.GetBytes(query);

        int lastPrefixIndex = 0;
        int serviceIndex = FindPrefixIndex(stateBytes, servicePrefix);
        if (serviceIndex != -1)
        {
            lastPrefixIndex = serviceIndex + servicePrefix.Length;
        }

        int queryIndex = FindPrefixIndex(stateBytes, queryPrefix);
        if (queryIndex != -1)
        {
            lastPrefixIndex = queryIndex + queryPrefix.Length;
        }

        return lastPrefixIndex;
    }

    private static int FindPrefixIndex(byte[] data, byte[] prefix)
    {
        for (int i = 0; i <= data.Length - prefix.Length; i++)
        {
            bool match = true;
            for (int j = 0; j < prefix.Length; j++)
            {
                if (data[i + j] != prefix[j])
                {
                    match = false;
                    break;
                }
            }
            if (match)
            {
                return i;
            }
        }
        return -1;
    }

    public static object DecodeQueryResult(byte[] queryBytes, string type, string query)
    {
        if (!ValidateInputs(queryBytes, type, query))
        {
            return null;
        }

        return ExecuteDecoding(queryBytes, type);
    }

    private static bool ValidateInputs(byte[] queryBytes, string type, string query)
    {
        if (queryBytes == null || queryBytes.Length == 0)
        {
            LogError("Query bytes are null or empty.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(type))
        {
            LogError("Type is null or empty.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(query))
        {
            LogError("Query is null or empty.");
            return false;
        }

        return true;
    }

    private static object ExecuteDecoding(byte[] queryBytes, string type)
    {
        try
        {
            IDecoder decoder = DecoderFactory.GetDecoder(type);
            return decoder.Decode(queryBytes);
        }
        catch (NotSupportedException ex)
        {
            LogError($"Decoding failed: {ex.Message}");
            return null;
        }
        catch (Exception ex)
        {
            LogError($"Unexpected error during decoding: {ex.Message}");
            return null;
        }
    }

    private static void LogError(string message)
    {

        Debug.LogError(message);
    }




    public class RpcResult
    {
        public List<int> Payload { get; set; }
        public int Value { get; set; }
        public Code Code { get; set; }
        public int Id { get; set; }
    }

    public class Code
    {
        public Error Error { get; set; }
    }

    public class Error
    {
        public string Execution { get; set; }
    }
}
