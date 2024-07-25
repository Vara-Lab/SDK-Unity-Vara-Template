using UnityEngine;
using System;
using Schnorrkel.Keys;
using System.Threading;
using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.Vara.NET.NetApiExt.Generated.Storage;
using VaraExt = Substrate.Vara.NET.NetApiExt.Generated;
using Substrate.Vara.NET.NetApiExt.Generated.Model.sp_core.crypto;

public class TransferKeepAlive : MonoBehaviour
{
    private VaraExt.SubstrateClientExt _clientvara; // Substrate client to interact with the Vara network
    private string url; // Test network node URL

    // Property to get Alice's MiniSecret key
    public static MiniSecret MiniSecretAlice
    {
        get
        {
            var bytes = Utils.HexToByteArray("496f9222372eca011351630ad276c7d44768a593cecea73685299e06acef8c0a");
            if (bytes == null || bytes.Length == 0)
            {
                throw new ArgumentException("HexToByteArray returned null or empty array");
            }
            return new MiniSecret(bytes, ExpandMode.Ed25519);
        }
    }

    // Property to get Alice's account
    public static Account Alice
    {
        get
        {
            var secret = MiniSecretAlice.ExpandToSecret().ToBytes();
            var publicKey = MiniSecretAlice.GetPair().Public.Key;

            if (secret == null || secret.Length == 0)
            {
                throw new ArgumentException("ExpandToSecret returned null or empty array");
            }
            if (publicKey == null || publicKey.Length == 0)
            {
                throw new ArgumentException("GetPair().Public.Key returned null or empty array");
            }

            return Account.Build(KeyType.Sr25519, secret, publicKey);
        }
    }

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

            // Define the amount to transfer
            var amount = new BaseCom<U128>(4000000000000);

            // Create the recipient account
            var account32 = new AccountId32();
            account32.Create("0xe4fa3b466792dcd7e58f5d8d49bc4631b5eec3a9ebe48ffe79f859dadf76cb71");
            var multiAddress = new VaraExt.Model.sp_runtime.multiaddress.EnumMultiAddress();
            multiAddress.Create(VaraExt.Model.sp_runtime.multiaddress.MultiAddress.Id, account32);

            // Vara Account (Alice's account)
            var aliceaccount32 = new AccountId32();
            aliceaccount32.Create("0x96bc6c65c1a0579886003e9c796ac1a9a9e9c4abc7b74d3b1cf399aaf35d7139");

            // Get the parameters needed to query account storage
            string parameters = SystemStorage.AccountParams(aliceaccount32);

            // Query the account info from the storage asynchronously
            var accountInfo = await _clientvara.GetStorageAsync<VaraExt.Model.frame_system.AccountInfo>(parameters, null, CancellationToken.None);

            // Log the free balance of the account
            Debug.Log($"Balance: {accountInfo.Data.Free}");

            // Prepare the transferKeepAlive method call
            var transferKeepAlive = BalancesCalls.TransferKeepAlive(multiAddress, amount);

            Debug.Log($"Extrinsic submitted: {transferKeepAlive}");

            uint lifeTime = 64; // Set the lifetime for the extrinsic

            // Send the extrinsic to the network and watch its status
            var sendExtrinsic = await _clientvara.Author.SubmitAndWatchExtrinsicAsync(ExtrinsicStatusCallback, transferKeepAlive, Alice, ChargeTransactionPayment.Default(), lifeTime);

            Debug.Log($"extrinsic=> {sendExtrinsic}");
        }
        else
        {
            // Log a message indicating that the client is not connected
            Debug.Log("Client is not connected.");
        }
    }

    // Define the callback method for extrinsic status
    private void ExtrinsicStatusCallback(string subscriptionId, ExtrinsicStatus status)
    {
        Debug.Log($"Subscription ID: {subscriptionId}");
        Debug.Log($"Extrinsic Status: {status}");
    }

    // Update is called once per frame
    void Update()
    {
        // You can add code here to be executed in each frame
    }
}
