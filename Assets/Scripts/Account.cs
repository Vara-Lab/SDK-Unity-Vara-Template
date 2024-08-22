using UnityEngine;

public class Account : MonoBehaviour
{
    async void Start()
    {
        // Hexadecimal seed used for account generation. This seed should be kept secure.
        string hexSeed = "496f9222372eca011351630ad276c7d44768a593cecea73685299e06acef8c0a";

        // Generate the account using the provided seed. 
        // This step involves key derivation and conversion from the seed to a public/private key pair.
        var account = AccountService.GenerateAccount(hexSeed);

        // Log the generated account address. This is typically used for debugging purposes.
        // Note: Ensure that sensitive information like private keys or seeds are not logged in production environments.
        Debug.Log($"Address: {account}");
    }
}
