using UnityEngine;
using Substrate.NetApi.Model.Types.Primitive;

public class ProgramSendMessage : MonoBehaviour
{
    // The WebSocket URL for connecting to the test network of the Vara blockchain.
    private string url = "wss://testnet.vara.network";

    async void Start()
    {
        // Hexadecimal seed used to generate the sender's account (Alice's account).
        // This seed is sensitive information and should be kept secure.
        string hexSeed = "496f9222372eca011351630ad276c7d44768a593cecea73685299e06acef8c0a";

        // Generate Alice's account using the provided seed.
        var aliceAccount = AccountService.GenerateAccount(hexSeed);

        // Define the smart contract service and function to call.
        // 'TrafficLight' is the service, and 'Red' is the function.
        string service = "TrafficLight";
        string function = "Red";

        // The program ID representing the deployed contract on the Vara blockchain.
        string programId = "0xd77336c9c6b6299f4260d520e96a2705e1cc290a242d1c2ad54999410bc77d85";

        // Define the gas limit for executing the transaction. This sets how much computational effort can be used.
        U64 gasLimit = new U64(90000000000); // Arbitrary high gas limit for this transaction.

        // Define the value (funds) being sent with the transaction. U128 is used to define the amount.
        U128 value = new U128(0); // No value is sent with this message, only function execution.

        // Specify whether the account should remain alive (keepAlive). 
        // If true, the account won't be removed even if its balance drops to zero after the transaction.
        bool keepAlive = true;

        // Asynchronously send the message to the smart contract using VaraService.
        // No additional payload is included (set to null).
        string result = await VaraService.SendMessageAsync(
            url, service, function, programId, aliceAccount, gasLimit, value, keepAlive, payload: null
        );

        // Log the result of the message sending operation to the Unity console.
        // This will show the transaction status or result, useful for debugging.
        Debug.Log($"Result: {result}");
    }
}
