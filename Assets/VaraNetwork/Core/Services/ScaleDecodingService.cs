using UnityEngine;
using System.Collections.Generic;
using System.Text;
using System;

public static class ScaleDecodingService
{
    /// <summary>
    /// Decodes a SCALE encoded byte array to the specified type.
    /// </summary>
    /// <param name="scaleData">The SCALE encoded byte array.</param>
    /// <param name="type">The type to decode to (e.g., "str", "IoTrafficLightState", "vec struct { actor_id, str }").</param>
    /// <returns>The decoded object as a string representation.</returns>
     public static T Decode<T>(string type, byte[] scaleData)
    {
        object result = type switch
        {
            "str" => DecodeStringField(scaleData),
            "vec struct { actor_id, str }" => DecodeVecActorIdStr(scaleData),
            _ => throw new NotSupportedException($"The type '{type}' is not supported for decoding.")
        };

        return (T)result;
    }

    private static List<(string, string)> DecodeVecActorIdStr(byte[] scaleData)
    {
        int index = 0; 

        List<(string, string)> allUsers = new List<(string, string)>();
        int numberOfUsers = DecodeCompactLength(scaleData, ref index);



        Debug.Log($"Number of Users: {numberOfUsers}");
        Debug.Log($"Initial Index: {index}");

        for (int i = 0; i < numberOfUsers; i++)
        {
            string actorId = DecodeActorId(scaleData, ref index);
            Debug.Log($"Actor ID: {actorId} at index {index}");
            string userName = DecodeString(scaleData, ref index);
            Debug.Log($"User Name: {userName} at index {index}");
            allUsers.Add((actorId, userName));
        }

        Debug.Log($"Here");
        Debug.Log($"Here");

        return allUsers;
    }

    private static string DecodeString(byte[] bytes, ref int index)
    {
        int length = DecodeCompactLength(bytes, ref index);
        if (index + length > bytes.Length)
            throw new ArgumentOutOfRangeException("Index and count must refer to a location within the buffer.");
        string value = Encoding.UTF8.GetString(bytes, index, length);
        index += length;
        return value;
    }

    private static string DecodeActorId(byte[] bytes, ref int index)
    {
        int length = 32; 

        Debug.Log($"Decoding Actor ID of length {length} at index {index}");

        if (index + length > bytes.Length)
            throw new ArgumentOutOfRangeException(nameof(index), "Index and count must refer to a location within the buffer.");

        string value = "0x" + BitConverter.ToString(bytes, index, length).Replace("-", "").ToLower();
        index += length; 
        Debug.Log($"Decoded Actor ID: {value}");
        return value;
    }
    private static int DecodeCompactLength(byte[] bytes, ref int index)
    {
        if (index + 1 > bytes.Length)
            throw new ArgumentOutOfRangeException("Index and count must refer to a location within the buffer.");
        byte firstByte = bytes[index];
        index += 1;

        int length;
        if ((firstByte & 0x03) == 0x00)
        {
            length = firstByte >> 2;
        }
        else if ((firstByte & 0x03) == 0x01)
        {
            if (index + 1 > bytes.Length)
                throw new ArgumentOutOfRangeException("Index and count must refer to a location within the buffer.");
            length = ((firstByte >> 2) | (bytes[index] << 6)) & 0x3FFF;
            index += 1;
        }
        else if ((firstByte & 0x03) == 0x02)
        {
            if (index + 3 > bytes.Length)
                throw new ArgumentOutOfRangeException("Index and count must refer to a location within the buffer.");
            length = (firstByte >> 2) |
                     (bytes[index] << 6) |
                     (bytes[index + 1] << 14) |
                     (bytes[index + 2] << 22);
            index += 3;
        }
        else if ((firstByte & 0x03) == 0x03)
        {
            if (index + 4 > bytes.Length)
                throw new ArgumentOutOfRangeException("Index and count must refer to a location within the buffer.");
            length = BitConverter.ToInt32(bytes, index);
            index += 4;
        }
        else
        {
            throw new Exception("Unsupported compact length encoding");
        }

        return length;
    }




    private static string DecodeStringField(byte[] scaleData)
    {
        return Encoding.UTF8.GetString(scaleData);

    }

}
