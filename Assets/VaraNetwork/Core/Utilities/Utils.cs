using System;
using System.Numerics;

public static class Utilities
    {
        /// <summary>
        /// Concatenates multiple byte arrays into a single byte array (payload).
        /// </summary>
        /// <param name="fields">Byte arrays to concatenate.</param>
        /// <returns>A single concatenated byte array.</returns>
        public static byte[] ConcatenatePayload(params byte[][] fields)
        {
            if (fields == null || fields.Length == 0)
                throw new ArgumentException("At least one byte array must be provided.", nameof(fields));

            int totalLength = 0;
            foreach (var field in fields)
            {
                if (field == null)
                    throw new ArgumentNullException(nameof(fields), "One of the byte arrays is null.");
                totalLength += field.Length;
            }

            byte[] payload = new byte[totalLength];
            int currentPosition = 0;
            foreach (var field in fields)
            {
                Buffer.BlockCopy(field, 0, payload, currentPosition, field.Length);
                currentPosition += field.Length;
            }

            return payload;
        }

        /// <summary>
        /// Converts a BigInteger representing a U256 value to a 32-byte array.
        /// </summary>
        /// <param name="u256">The BigInteger value to convert.</param>
        /// <returns>A 32-byte array representing the U256 value.</returns>
        public static byte[] U256ToByteArray(BigInteger u256)
        {
            if (u256.Sign < 0)
                throw new ArgumentException("U256 values cannot be negative.", nameof(u256));

            byte[] bytes = u256.ToByteArray();

            if (bytes.Length > 32)
                throw new ArgumentException("The value is too large to be represented in 32 bytes.", nameof(u256));

            // Ensure the byte array has 32 bytes in length
            byte[] paddedBytes = new byte[32];
            Array.Copy(bytes, 0, paddedBytes, 32 - bytes.Length, bytes.Length);

            // Convert from little-endian to big-endian
            Array.Reverse(paddedBytes);

            return paddedBytes;
        }

        /// <summary>
        /// Converts a hexadecimal string to a byte array.
        /// </summary>
        /// <param name="hex">The hexadecimal string to convert.</param>
        /// <returns>A byte array representing the hexadecimal string.</returns>
        public static byte[] HexStringToByteArray(string hex)
        {
            if (string.IsNullOrEmpty(hex))
                throw new ArgumentException("Hex string cannot be null or empty.", nameof(hex));

            // Remove "0x" prefix if present
            if (hex.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                hex = hex.Substring(2);

            // Ensure the string length is even
            if (hex.Length % 2 != 0)
                throw new ArgumentException("Hex string length must be even.", nameof(hex));

            byte[] bytes = new byte[hex.Length / 2];

            for (int i = 0; i < hex.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }

            return bytes;
        }
    }