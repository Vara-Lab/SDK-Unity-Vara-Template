using UnityEngine;
using System;


public class ProgramReadState : MonoBehaviour
{
  // The WebSocket URL for connecting to the Vara blockchain test network.
  private string url = "wss://testnet.vara.network";

  async void Start()
  {
    // Define the service and function to interact with in the smart contract.
    string service = "Vft";

    // The query that will be executed on the contract to retrieve the current state.
    string query = "Name";

    // Expected return type of the query.
    string type = "String";


    // The sender's address in hexadecimal format, which will be used to sign the transaction or query.
    string sender = "0xe4fa3b466792dcd7e58f5d8d49bc4631b5eec3a9ebe48ffe79f859dadf76cb71";

    // The program ID corresponding to the deployed contract on the Vara blockchain.
    string programId = "0x9b70e858462eedf89896808af3082673b740404961c118109a2217536c907f5a";


    // Set the gas limit for executing the transaction or query. This defines the computational resources allocated for the operation.
    long gasLimit = 100000000000; // High gas limit to ensure execution.

    // Set the value being sent along with the transaction. For this query, no value is transferred, so it's set to zero.
    int value = 0;

    // Asynchronously query the state of the smart contract using the QueryService.
    // The query will return the current state as described in the IDL.
    object result = await QueryService.QueryStateAsync(
        url, service, query, type, sender, programId, gasLimit, value, payload: null
    );

    

    Debug.Log($"Result: {result}");





  }


 


}

