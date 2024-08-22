using UnityEngine;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Primitive;

public class VaraTransfers : MonoBehaviour
{
    // The WebSocket URL for connecting to the test network of the Vara blockchain.
    private string url = "wss://testnet.vara.network";

    async void Start()
    {
        // Hexadecimal seed used to generate the sender's account (Alice's account).
        // This seed should be kept secure as it can be used to regenerate the account's private keys.
        string hexSeed = "496f9222372eca011351630ad276c7d44768a593cecea73685299e06acef8c0a";
        
        // Generate the account for Alice using the provided seed.
        var aliceAccount = AccountService.GenerateAccount(hexSeed);

        // The recipient's address in hexadecimal format.
        string recipientAddress = "0xe4fa3b466792dcd7e58f5d8d49bc4631b5eec3a9ebe48ffe79f859dadf76cb71";

        // The amount to transfer, specified in the smallest unit of the currency .
        long amount = 2000000000000;
        
        // Asynchronously execute the transfer from Alice's account to the recipient's address.
        // The result is a transaction hash or status indicating the success of the transfer.
        string result = await VaraTransferService.TransferAsync(url, aliceAccount, recipientAddress, amount);

        // Log the result of the transfer to the Unity console.
        // This is useful for debugging and verifying that the transfer was successful.
        Debug.Log($"Result: {result}");
    }
}
