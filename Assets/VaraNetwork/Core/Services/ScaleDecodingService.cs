using UnityEngine;
using System.Collections.Generic;
using System.Text;
using System;
using System.Numerics;


public static class ScaleDecodingService
{
    /// <summary>
    /// Decodes a SCALE encoded byte array to the specified type.
    /// </summary>
    /// <param name="scaleData">The SCALE encoded byte array.</param>
    /// <param name="type">The type to decode to (e.g., "str", "u128", "vec struct { actor_id, str }").</param>
    /// <returns>The decoded object as a string representation.</returns>
    public static T Decode<T>(string type, byte[] scaleData)
    {
        int index = 0;
        object result = type switch
        {
            "String" => DecodeStringField(scaleData),
            "vec struct { actor_id, str }" => DecodeVecActorIdStr(scaleData, ref index),
            "[u8;32]" => DecodeActorId(scaleData, ref index),
            "u8" => DecodeU8(scaleData, ref index),
            "u16" => DecodeU16(scaleData, ref index),
            "u32" => DecodeU32(scaleData, ref index),
            "u64" => DecodeU64(scaleData, ref index),
            "u128" => DecodeU128(scaleData, ref index),
            "i8" => DecodeI8(scaleData, ref index),
            "i16" => DecodeI16(scaleData, ref index),
            "i32" => DecodeI32(scaleData, ref index),
            "i64" => DecodeI64(scaleData, ref index),
            "U256" => DecodeU256(scaleData, ref index),
            "Vec<[u8;32]>" => DecodeVecActorId(scaleData, ref index),

            _ => throw new NotSupportedException($"The type '{type}' is not supported for decoding.")
        };

        return (T)result;
    }
    public static List<string> DecodeVecActorId(byte[] scaleData, ref int index)
    {
        List<string> actorIds = new List<string>();
        int numberOfUsers = DecodeCompactLength(scaleData, ref index);

        for (int i = 0; i < numberOfUsers; i++)
        {
            string actorId = DecodeActorId(scaleData, ref index);
            Debug.Log($"Actor ID: {actorId} at index {index}");
            actorIds.Add(actorId);
            DecodeStringField(scaleData);
        }

        return actorIds;
    }

    public static List<(string, string)> DecodeVecActorIdStr(byte[] scaleData, ref int index)
    {


        List<(string, string)> all = new List<(string, string)>();
        int numberOfUsers = DecodeCompactLength(scaleData, ref index);


        for (int i = 0; i < numberOfUsers; i++)
        {
            string actorId = DecodeActorId(scaleData, ref index);
            Debug.Log($"Actor ID: {actorId} at index {index}");
            string strType = DecodeString(scaleData, ref index);
            Debug.Log($"User Name: {strType} at index {index}");
            all.Add((actorId, strType));
        }


        return all;
    }

    public static string DecodeString(byte[] bytes, ref int index)
    {
        int length = DecodeCompactLength(bytes, ref index);
        if (index + length > bytes.Length)
            throw new ArgumentOutOfRangeException("Index and count must refer to a location within the buffer.");
        string value = Encoding.UTF8.GetString(bytes, index, length);
        index += length;
        return value;
    }

    public static string DecodeActorId(byte[] bytes, ref int index)
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
    public static int DecodeCompactLength(byte[] bytes, ref int index)
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




    public static string DecodeStringField(byte[] scaleData)
    {
        return Encoding.UTF8.GetString(scaleData);

    }

    public static byte DecodeU8(byte[] bytes, ref int index)
    {
        if (index + sizeof(byte) > bytes.Length)
            throw new ArgumentOutOfRangeException("Index and count must refer to a location within the buffer.");
        byte value = bytes[index];
        index += sizeof(byte);
        return value;
    }

    public static ushort DecodeU16(byte[] bytes, ref int index)
    {
        if (index + sizeof(ushort) > bytes.Length)
            throw new ArgumentOutOfRangeException("Index and count must refer to a location within the buffer.");
        ushort value = BitConverter.ToUInt16(bytes, index);
        index += sizeof(ushort);
        return value;
    }

    public static uint DecodeU32(byte[] bytes, ref int index)
    {
        if (index + sizeof(uint) > bytes.Length)
            throw new ArgumentOutOfRangeException("Index and count must refer to a location within the buffer.");
        uint value = BitConverter.ToUInt32(bytes, index);
        index += sizeof(uint);
        return value;
    }

    public static ulong DecodeU64(byte[] bytes, ref int index)
    {
        if (index + sizeof(ulong) > bytes.Length)
            throw new ArgumentOutOfRangeException("Index and count must refer to a location within the buffer.");
        ulong value = BitConverter.ToUInt64(bytes, index);
        index += sizeof(ulong);
        return value;
    }

    public static BigInteger DecodeU128(byte[] bytes, ref int index)
    {
        if (index + 16 > bytes.Length) // 16 bytes = 128 bits
            throw new ArgumentOutOfRangeException("Index and count must refer to a location within the buffer.");

        byte[] u128Bytes = new byte[16];
        Array.Copy(bytes, index, u128Bytes, 0, 16);
        index += 16;

        // Big-endian conversion (if necessary)
        Array.Reverse(u128Bytes);
        return new BigInteger(u128Bytes);
    }

    public static string DecodeU256(byte[] bytes, ref int index)
    {
        if (index + 32 > bytes.Length)
            throw new ArgumentOutOfRangeException("Index and count must refer to a location within the buffer.");

        byte[] u256Bytes = new byte[32];
        Array.Copy(bytes, index, u256Bytes, 0, 32);
        index += 32;

        var result = new BigInteger(u256Bytes);

        string hexValue = result.ToString("X").PadLeft(64, '0');

        return "0x" + hexValue;
    }


    public static sbyte DecodeI8(byte[] bytes, ref int index)
    {
        if (index + sizeof(sbyte) > bytes.Length)
            throw new ArgumentOutOfRangeException("Index and count must refer to a location within the buffer.");
        sbyte value = (sbyte)bytes[index];
        index += sizeof(sbyte);
        return value;
    }

    public static short DecodeI16(byte[] bytes, ref int index)
    {
        if (index + sizeof(short) > bytes.Length)
            throw new ArgumentOutOfRangeException("Index and count must refer to a location within the buffer.");
        short value = BitConverter.ToInt16(bytes, index);
        index += sizeof(short);
        return value;
    }

    public static int DecodeI32(byte[] bytes, ref int index)
    {
        if (index + sizeof(int) > bytes.Length)
            throw new ArgumentOutOfRangeException("Index and count must refer to a location within the buffer.");
        int value = BitConverter.ToInt32(bytes, index);
        index += sizeof(int);
        return value;
    }

    public static long DecodeI64(byte[] bytes, ref int index)
    {
        if (index + sizeof(long) > bytes.Length)
            throw new ArgumentOutOfRangeException("Index and count must refer to a location within the buffer.");
        long value = BitConverter.ToInt64(bytes, index);
        index += sizeof(long);
        return value;
    }


}
