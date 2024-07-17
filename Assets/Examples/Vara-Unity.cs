using Substrate.NetApi.Model.Extrinsics;
using System;
using System.Threading;
using UnityEngine;
using VaraExt = Substrate.Vara.NET.NetApiExt.Generated;

public class Test : MonoBehaviour
{
    private VaraExt.SubstrateClientExt _clientvara;
    private string url;

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
            // Log a message indicating that the client is connected
            Debug.Log("Client is connected.");

            // Call the Number method of the system storage with the given key and no cancellation token
            var numberTask = _clientvara.SystemStorage.Number("0x1c0993e96022b0c077df64d923ac1fbdae5de5e9f0022c444465c67b0960ce5b", CancellationToken.None);

            // Await the task to complete and retrieve the data
            var data = await numberTask;

            // Log the retrieved data to the debug console and the standard console
            Debug.Log($"Data: {data}");
        }
        else
        {
            // Log a message indicating that the client is not connected
            Debug.Log("Client is not connected.");
        }
    }

  void Update()
    {
        // You can add code here to be executed in each frame
    }
}