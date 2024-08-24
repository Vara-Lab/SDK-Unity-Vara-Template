using UnityEngine;
using System;
using System.Numerics;
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
        string service = "Vft";
        string function = "TransferFrom";

        // The program ID representing the deployed contract on the Vara blockchain.
        string programId = "0x9b70e858462eedf89896808af3082673b740404961c118109a2217536c907f5a";

        byte[] from = Utilities.HexStringToByteArray("0x96bc6c65c1a0579886003e9c796ac1a9a9e9c4abc7b74d3b1cf399aaf35d7139");

        byte[] to = Utilities.HexStringToByteArray("0xe4fa3b466792dcd7e58f5d8d49bc4631b5eec3a9ebe48ffe79f859dadf76cb71");

        byte[] amount = Utilities.U256ToByteArray(50);

        byte[] payload = Utilities.ConcatenatePayload(from,to, amount);


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
            url, service, function, programId, aliceAccount, gasLimit, value, keepAlive, payload
        );

        // Log the result of the message sending operation to the Unity console.
        // This will show the transaction status or result, useful for debugging.
        Debug.Log($"Result: {result}");
    }



}
