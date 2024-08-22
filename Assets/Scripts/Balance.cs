using UnityEngine;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Primitive;

public class Balance : MonoBehaviour
{
    // The WebSocket URL for connecting to the test network of the Vara blockchain.
    private string url = "wss://testnet.vara.network";

    async void Start()
    {
        // Asynchronously fetch the account balance for the specified account address.
        // The address is provided in hex format.
        U128 balance = await BalanceService.GetAccountBalanceAsync(url, "0x96bc6c65c1a0579886003e9c796ac1a9a9e9c4abc7b74d3b1cf399aaf35d7139");

        // Log the retrieved balance to the Unity console.
        // This is useful for debugging and verifying that the correct balance is retrieved.
        Debug.Log($"Result: {balance}");
    }
}
