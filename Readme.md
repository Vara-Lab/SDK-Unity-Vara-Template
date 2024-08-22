# SDK Unity Vara Network Template

This repository contains a template for integrating the Vara network into Unity projects using the Substrate SDK. It provides examples and utilities to facilitate connection and interaction with Vara network.

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [License](#license)

## Introduction

The SDK Unity Vara Network Template is designed to simplify the integration of the Vara network into your Unity projects. It provides a basic setup and examples of how to connect and communicate with Vara Network.

## Features

- Easy connection to Vara network nodes.
- Examples of Substrate API calls.
- Key and account management.
- Examples of transactions and runtime queries.

## Prerequisites

Before getting started, ensure you have the following components installed:

- [Unity](https://unity.com/) (version 2019.4 or higher)
- [.NET Core SDK](https://dotnet.microsoft.com/download)

## Installation

To use this template in your Unity project, follow these steps:

1. Clone the repository:

   ```sh
   git clone https://github.com/Vara-Lab/SDK-Unity-Vara-Template.git

2. Open the project in Unity:

    1. Open Unity Hub.
    2. Select "Add" and navigate to the cloned repository folder.
    3. Select the folder and click "Open".


## Examples

### Account

This example demonstrates how to generate an account in Unity using a hexadecimal seed. The seed is converted into a public/private key pair, and the generated account address is logged for debugging.

```csharp
using UnityEngine;

public class Account : MonoBehaviour
{
    async void Start()
    {
        // Hexadecimal seed used for account generation. This seed should be kept secure.
        string hexSeed = "......";

        // Generate the account using the provided seed. 
        // This step involves key derivation and conversion from the seed to a public/private key pair.
        var account = AccountService.GenerateAccount(hexSeed);

        // Log the generated account address. This is typically used for debugging purposes.
        // Note: Ensure that sensitive information like private keys or seeds are not logged in production environments.
        Debug.Log($"Address: {account}");
    }
}

```
### Balance

This example shows how to retrieve and display the balance of a specific account on the Vara test network. The account address is provided in hexadecimal format.

```csharp
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

```

### Transfer

This example demonstrates how to transfer funds from one account to another on the Vara network. The transaction is signed using the sender's account and the result is logged.

```csharp
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
        string hexSeed = ".......";
        
        // Generate the account for Alice using the provided seed.
        var aliceAccount = AccountService.GenerateAccount(hexSeed);

        // The recipient's address in hexadecimal format.
        string recipientAddress = "0x..........";

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

```

### ProgramSendMessage

This example illustrates how to send a message to a smart contract deployed on the Vara blockchain. It includes setting up the necessary parameters such as gas limit and program ID.

```csharp
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
        string hexSeed = ".......";

        // Generate Alice's account using the provided seed.
        var aliceAccount = AccountService.GenerateAccount(hexSeed);

        // Define the smart contract service and function to call.
        // 'TrafficLight' is the service, and 'Red' is the function.
        string service = "MyService";
        string function = "function";

        // The program ID representing the deployed contract on the Vara blockchain.
        string programId = "0x......";

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


```

### ProgramReadState

This example demonstrates how to query the state of a smart contract on the Vara network. The contract is defined using an Interface Description Language (IDL), and the query results are logged.

```csharp
using UnityEngine;

public class ProgramReadState : MonoBehaviour
{
    // The WebSocket URL for connecting to the Vara blockchain test network.
    private string url = "wss://testnet.vara.network";

    async void Start()
    {
        // Define the service and function to interact with in the smart contract.
        // 'TrafficLight' is the service.
        string service = "TrafficLight";

        // The query that will be executed on the contract to retrieve the current state.
        string query = "Current";

        // The sender's address in hexadecimal format, which will be used to sign the transaction or query.
        string sender = "0xe4fa3b466792dcd7e58f5d8d49bc4631b5eec3a9ebe48ffe79f859dadf76cb71";

        // The program ID corresponding to the deployed contract on the Vara blockchain.
        string programId = "0xd77336c9c6b6299f4260d520e96a2705e1cc290a242d1c2ad54999410bc77d85";

        // Set the gas limit for executing the transaction or query. This defines the computational resources allocated for the operation.
        long gasLimit = 100000000000; // High gas limit to ensure execution.

        // Set the value being sent along with the transaction. For this query, no value is transferred, so it's set to zero.
        int value = 0;

        // Define the Interface Description Language (IDL) for the smart contract.
        // The IDL describes the structure of types and services provided by the contract, which helps in decoding the results of queries and calls.
        string idl = @"My IDL....;";

        // Asynchronously query the state of the smart contract using the QueryService.
        // The query will return the current state as described in the IDL.
        object result = await QueryService.QueryStateAsync(
            url, idl, service, query, sender, programId, gasLimit, value, payload: null
        );

        // Log the result of the query to the Unity console for debugging and verification.
        Debug.Log($"Result: {result}");
    }
}

```

### Explanation

1. **Assign the test node URL to the variable `url`**: This line assigns the test node URL to the `url` variable.
2. **Initialize the Substrate client**: Initializes the `SubstrateClientExt` with the provided URL and default transaction payment method.
3. **Connect the client asynchronously**: Connects the client to the node asynchronously using `ConnectAsync`.
4. **Check if the client is connected**: Checks if the client is not null and is connected using the `IsConnected` property.
5. **Retrieve data from the system storage**: Calls the `Number` method on the system storage with a specific key and waits for the task to complete.
6. **Log the data**: Logs the retrieved data to both the Unity debug console and the standard console.

This should help users understand how to use the `SubstrateClientExt` to connect to a Vara network node and interact with it.

## Contributing

We welcome contributions to this project! If you'd like to contribute, please follow these guidelines:

1. **Fork the Repository**:  
   Click on the "Fork" button at the top of this repository to create your own copy.

2. **Create a Feature Branch**:  
   Create a new branch for your feature or bugfix.
   ```bash
   git checkout -b feature/your-feature-name
   ```

3. **Submit a Pull Request**:  
   Once your changes are ready, submit a pull request to the `main` branch. Be sure to include a detailed description of your changes and the problem they solve.

## License
This project is licensed under the MIT License. See the LICENSE file for details.