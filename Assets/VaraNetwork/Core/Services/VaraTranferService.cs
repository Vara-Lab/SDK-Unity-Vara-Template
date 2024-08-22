using UnityEngine;
using System;
using System.Threading.Tasks;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.Vara.NET.NetApiExt.Generated.Storage;
using Substrate.Vara.NET.NetApiExt.Generated.Model.sp_core.crypto;
using Substrate.NetApi.Model.Types.Base;
using VaraExt = Substrate.Vara.NET.NetApiExt.Generated;




public static class VaraTransferService
{
    private static VaraExt.SubstrateClientExt _client;
    private static string _currentUrl;

    /// <summary>
    /// Initializes the client and connects to the specified URL if not already connected.
    /// </summary>
    private static async Task InitializeClientAsync(string url)
    {
        if (_client == null || _currentUrl != url)
        {
            _currentUrl = url;
            _client = new VaraExt.SubstrateClientExt(new Uri(url), ChargeTransactionPayment.Default());
            await _client.ConnectAsync();
        }

        if (!_client.IsConnected)
        {
            throw new Exception("Client is not connected.");
        }
    }

    /// <summary>
    /// Transfers a specified amount.
    /// </summary>
    /// <param name="url">The URL of the node to connect to.</param>
    /// <param name="recipientAddress">The recipient's account address as a string.</param>
    /// <param name="amount">The amount to transfer.</param>
    /// <returns>The result of the transfer extrinsic.</returns>
    public static async Task<string> TransferAsync(string url, Substrate.NetApi.Model.Types.Account from , string recipientAddress, long amount)
    {
        await InitializeClientAsync(url);


        // Create the recipient account
        var account32 = new AccountId32();
        account32.Create(recipientAddress);
        var multiAddress = new VaraExt.Model.sp_runtime.multiaddress.EnumMultiAddress();
        multiAddress.Create(VaraExt.Model.sp_runtime.multiaddress.MultiAddress.Id, account32);

         // Define the amount to transfer
        var amountBaseCom = new BaseCom<U128>(amount);

        // Prepare the transferKeepAlive method call
        var transferKeepAlive = BalancesCalls.TransferKeepAlive(multiAddress, amountBaseCom);

        Debug.Log($"Extrinsic prepared: {transferKeepAlive}");

        uint lifeTime = 64; // Set the lifetime for the extrinsic

        // Send the extrinsic to the network and watch its status
        var sendExtrinsic = await _client.Author.SubmitAndWatchExtrinsicAsync(ExtrinsicStatusCallback, transferKeepAlive, from, ChargeTransactionPayment.Default(), lifeTime);

        Debug.Log($"extrinsic=> {sendExtrinsic}");

        return sendExtrinsic.ToString();
    }

   private static void ExtrinsicStatusCallback(string subscriptionId, ExtrinsicStatus status)
    {
        Debug.Log($"Subscription ID: {subscriptionId}");
        Debug.Log($"Extrinsic Status: {status}");
    }


}
