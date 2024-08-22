
using System;
using Schnorrkel.Keys;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types;


public static class AccountService
{
    /// <summary>
    /// Generates a MiniSecret from a hex seed.
    /// </summary>
    /// <param name="hexSeed">The seed in hexadecimal format.</param>
    /// <returns>A MiniSecret object.</returns>
    public static MiniSecret GenerateMiniSecret(string hexSeed)
    {
        var bytes = Utils.HexToByteArray(hexSeed);
        if (bytes == null || bytes.Length == 0)
        {
            throw new ArgumentException("HexToByteArray returned null or empty array");
        }
        return new MiniSecret(bytes, ExpandMode.Ed25519);
    }

    /// <summary>
    /// Generates an Account from a hex seed.
    /// </summary>
    /// <param name="hexSeed">The seed in hexadecimal format.</param>
    /// <returns>An Account object containing the secret and public key.</returns>
    public static Substrate.NetApi.Model.Types.Account GenerateAccount(string hexSeed)
    {
        var miniSecret = GenerateMiniSecret(hexSeed);
        var secret = miniSecret.ExpandToSecret().ToBytes();
        var publicKey = miniSecret.GetPair().Public.Key;

        if (secret == null || secret.Length == 0)
        {
            throw new ArgumentException("ExpandToSecret returned null or empty array");
        }
        if (publicKey == null || publicKey.Length == 0)
        {
            throw new ArgumentException("GetPair().Public.Key returned null or empty array");
        }

        return Substrate.NetApi.Model.Types.Account.Build(KeyType.Sr25519, secret, publicKey);
    }
}
