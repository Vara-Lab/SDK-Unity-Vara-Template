using UnityEngine;
using System;
using System.Threading;
using Substrate.NetApi.Model.Extrinsics;
using VaraExt = Substrate.Vara.NET.NetApiExt.Generated;



public class ReadState : MonoBehaviour
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


      string[] parametersArray = new string[] { "0xad5a7cc54276cd57abf7b0db8e462976dec5b10567155cea32436789c096f30b", "" };

      string text = await _clientvara.InvokeAsync<string>("gear_readState", parametersArray, CancellationToken.None);

      // Log the retrieved data to the debug console and the standard console
      Debug.Log($"Data: {text}");

    }
    else
    {
      // Log a message indicating that the client is not connected
      Debug.Log("Client is not connected.");
    }
  }

  void Update()
  {
   
  }
}

