using UnityEngine;
using System;
using System.Threading;
using System.Threading.Tasks; 
using Substrate.NetApi.Model.Extrinsics;
using Substrate.Vara.NET.NetApiExt.Generated.Storage;
using VaraExt = Substrate.Vara.NET.NetApiExt.Generated;
using Substrate.Vara.NET.NetApiExt.Generated.Model.sp_core.crypto;

public class VaraBalanceAccount : MonoBehaviour
{
    private VaraExt.SubstrateClientExt _clientvara; // Substrate client to interact with the Vara network
    private string url; // Test network node URL

    // Start is called before the first frame update
    async void Start()
    {
        // Assign the test node URL to the variable url
        url = "wss://testnet.vara.network";

        // Initialize the Substrate client with the node URL and the default transaction payment method
        _clientvara = new VaraExt.SubstrateClientExt(new Uri(url), ChargeTransactionPayment.Default());

        // Connect the client to the node asynchronously
        await _clientvara.ConnectAsync();

        // Check if the client is initialized and connected
        if (_clientvara != null && _clientvara.IsConnected)
        {
            // Add Vara Account
            await GetVaraAccountBalance("0xd43593c715fdd31c61141abd04a99fd6822c8558854ccde39a5684e7a56da27d");
        }
        else
        {
            // Log a message indicating that the client is not connected
            Debug.Log("Client is not connected.");
        }
    }

    // Asynchronous method to get the balance of a Vara account
    private async Task GetVaraAccountBalance(string account)
    {
        var accountId32 = new AccountId32();
        accountId32.Create(account); // Create AccountId32 instance from the provided account string

        // Get the parameters needed to query account storage
        string parameters = SystemStorage.AccountParams(accountId32);
        
        // Query the account info from the storage asynchronously
        var accountInfo = await _clientvara.GetStorageAsync<VaraExt.Model.frame_system.AccountInfo>(parameters, null, CancellationToken.None);

        // Log the free balance of the account
        Debug.Log($"Balance: {accountInfo.Data.Free}");
    }

    void Update()
    {
        // Currently empty, but can be used for other updates if needed
    }
}
