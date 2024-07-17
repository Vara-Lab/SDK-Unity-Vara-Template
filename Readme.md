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


## Example Usage of SubstrateClientExt

The following code snippet demonstrates how to initialize, connect, and interact with the Vara network using `SubstrateClientExt` in Unity. It includes comments to explain each step.

```csharp
// Assign the test node URL to the variable url
url = _testNode;

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
    var numberTask = ((VaraExt.SubstrateClientExt)_clientvara).SystemStorage.Number("0x84d1c0434d95f92501d18115c6df68b9cbed62aa75e3e7b9b031b0225acaafcc", CancellationToken.None);

    // Await the task to complete and retrieve the data
    var data = await numberTask;

    // Log the retrieved data to the debug console and the standard console
    Debug.Log($"Data: {data}");
    Console.WriteLine($"DataError: {data}");
}
else
{
    // Log a message indicating that the client is not connected
    Debug.Log("Client is not connected.");
}


### Explicación

1. **Assign the test node URL to the variable `url`**: This line assigns the test node URL to the `url` variable.
2. **Initialize the Substrate client**: Initializes the `SubstrateClientExt` with the provided URL and default transaction payment method.
3. **Connect the client asynchronously**: Connects the client to the node asynchronously using `ConnectAsync`.
4. **Check if the client is connected**: Checks if the client is not null and is connected using the `IsConnected` property.
5. **Retrieve data from the system storage**: Calls the `Number` method on the system storage with a specific key and waits for the task to complete.
6. **Log the data**: Logs the retrieved data to both the Unity debug console and the standard console.

This should help users understand how to use the `SubstrateClientExt` to connect to a Vara network node and interact with it.





## License
This project is licensed under the MIT License. See the LICENSE file for details.