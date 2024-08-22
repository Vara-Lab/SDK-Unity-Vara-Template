using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using VaraExt = Substrate.Vara.NET.NetApiExt.Generated;
using UnityEngine;
using Substrate.Vara.NET.NetApiExt.Generated.Storage;
using Substrate.Vara.NET.NetApiExt.Generated.Model.gear_core.ids;


public static class VaraService
{
    private static VaraExt.SubstrateClientExt _client;
    private static string _currentUrl;

    public static async Task<string> SendMessageAsync(
        string url,
        string service,
        string function,
        string programId,
        Substrate.NetApi.Model.Types.Account account,
        U64 gasLimit,
        U128 value,
        bool keepAlive,
        byte[] payload = null)
    {
        await EnsureClientConnectedAsync(url);

        if (!_client.IsConnected)
        {
            Debug.LogError("Client is not connected.");
            return null;
        }

        var destination = CreateProgramId(programId);
        var messagePayload = CreateMessagePayload(service, function, payload);

        Debug.Log($"Transaction : {ConvertToHex(messagePayload.Encode())}");

        var sendMessage = PrepareSendMessage(destination, messagePayload, gasLimit, value, keepAlive);
        Debug.Log($"Extrinsic prepared : {sendMessage}");

        return await SendExtrinsicAsync(sendMessage, account);
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

    private static ProgramId CreateProgramId(string programId)
    {
        var destination = new ProgramId();
        destination.Create(programId);
        return destination;
    }

    private static BaseVec<U8> CreateMessagePayload(string service, string function, byte[] payload)
    {
        var scaleBytes = EncodeToScale(service, function);
        var u8ScaleBytes = ConvertToU8Array(scaleBytes);

        if (payload == null)
        {
            return new BaseVec<U8>(u8ScaleBytes);
        }

        var u8MessagePayload = ConvertToU8Array(payload);
        var concatenatedArray = ConcatenateU8Arrays(u8ScaleBytes, u8MessagePayload);
        return new BaseVec<U8>(concatenatedArray);
    }

    private static U8[] ConvertToU8Array(byte[] byteArray)
    {
        return byteArray.Select(b => new U8(b)).ToArray();
    }

    private static U8[] ConcatenateU8Arrays(U8[] firstArray, U8[] secondArray)
    {
        return firstArray.Concat(secondArray).ToArray();
    }

    private static string ConvertToHex(byte[] data)
    {
        return "0x" + BitConverter.ToString(data).Replace("-", "").ToLower();
    }

    private static byte[] EncodeToScale(string service, string function)
    {
        byte[] serviceBytes = Encoding.ASCII.GetBytes(service);
        byte[] functionBytes = Encoding.ASCII.GetBytes(function);

        byte[] serviceLengthBytes = EncodeCompactInteger(serviceBytes.Length);
        byte[] functionLengthBytes = EncodeCompactInteger(functionBytes.Length);

        int totalLength = serviceLengthBytes.Length + serviceBytes.Length +
                          functionLengthBytes.Length + functionBytes.Length;

        byte[] combined = new byte[totalLength];
        int offset = 0;

        Array.Copy(serviceLengthBytes, 0, combined, offset, serviceLengthBytes.Length);
        offset += serviceLengthBytes.Length;
        Array.Copy(serviceBytes, 0, combined, offset, serviceBytes.Length);
        offset += serviceBytes.Length;

        Array.Copy(functionLengthBytes, 0, combined, offset, functionLengthBytes.Length);
        offset += functionLengthBytes.Length;
        Array.Copy(functionBytes, 0, combined, offset, functionBytes.Length);

        return combined;
    }

    private static byte[] EncodeCompactInteger(int value)
    {
        if (value <= 0x3F)
        {
            return new byte[] { (byte)(value << 2) };
        }
        else if (value <= 0x3FFF)
        {
            return new byte[] { (byte)((value << 2) | 0x01), (byte)(value >> 6) };
        }
        else if (value <= 0x3FFFFFFF)
        {
            return new byte[] { (byte)((value << 2) | 0x02), (byte)(value >> 6), (byte)(value >> 14), (byte)(value >> 22) };
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Value too large to be encoded as compact integer");
        }
    }

    private static Method PrepareSendMessage(ProgramId destination, BaseVec<U8> messagePayload, U64 gasLimit, U128 value, bool keepAlive)
    {
        var keepAliveOption = new Bool(keepAlive);
        return GearCalls.SendMessage(destination, messagePayload, gasLimit, value, keepAliveOption);
    }

    private static async Task<string> SendExtrinsicAsync(Method sendMessage, Substrate.NetApi.Model.Types.Account account)
    {
        const uint lifeTime = 64; // Set the lifetime for the extrinsic
        var sendExtrinsic = await _client.Author.SubmitAndWatchExtrinsicAsync(ExtrinsicStatusCallback, sendMessage, account, ChargeTransactionPayment.Default(), lifeTime);

        Debug.Log($"extrinsic=> {sendExtrinsic}");
        return sendExtrinsic.ToString();
    }

    private static void ExtrinsicStatusCallback(string subscriptionId, ExtrinsicStatus status)
    {
        Debug.Log($"Subscription ID: {subscriptionId}");
        Debug.Log($"Extrinsic Status: {status}");
    }
}