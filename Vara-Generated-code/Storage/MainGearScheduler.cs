//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Meta;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Substrate.Vara.NET.NetApiExt.Generated.Storage
{
    
    
    /// <summary>
    /// >> GearSchedulerStorage
    /// </summary>
    public sealed class GearSchedulerStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        /// <summary>
        /// >> GearSchedulerStorage Constructor
        /// </summary>
        public GearSchedulerStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("GearScheduler", "FirstIncompleteTasksBlock"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substrate.NetApi.Model.Types.Primitive.U32)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("GearScheduler", "TaskPool"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Identity,
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Identity}, typeof(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.Vara.NET.NetApiExt.Generated.Model.gear_common.scheduler.task.EnumScheduledTask>), typeof(Substrate.NetApi.Model.Types.Base.BaseTuple)));
        }
        
        /// <summary>
        /// >> FirstIncompleteTasksBlockParams
        /// </summary>
        public static string FirstIncompleteTasksBlockParams()
        {
            return RequestGenerator.GetStorage("GearScheduler", "FirstIncompleteTasksBlock", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> FirstIncompleteTasksBlockDefault
        /// Default value as hex string
        /// </summary>
        public static string FirstIncompleteTasksBlockDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> FirstIncompleteTasksBlock
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> FirstIncompleteTasksBlock(string blockhash, CancellationToken token)
        {
            string parameters = GearSchedulerStorage.FirstIncompleteTasksBlockParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> TaskPoolParams
        /// </summary>
        public static string TaskPoolParams(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.Vara.NET.NetApiExt.Generated.Model.gear_common.scheduler.task.EnumScheduledTask> key)
        {
            return RequestGenerator.GetStorage("GearScheduler", "TaskPool", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Identity,
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Identity}, key.Value);
        }
        
        /// <summary>
        /// >> TaskPoolDefault
        /// Default value as hex string
        /// </summary>
        public static string TaskPoolDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> TaskPool
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseTuple> TaskPool(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.Vara.NET.NetApiExt.Generated.Model.gear_common.scheduler.task.EnumScheduledTask> key, string blockhash, CancellationToken token)
        {
            string parameters = GearSchedulerStorage.TaskPoolParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseTuple>(parameters, blockhash, token);
            return result;
        }
    }
    
    /// <summary>
    /// >> GearSchedulerCalls
    /// </summary>
    public sealed class GearSchedulerCalls
    {
    }
    
    /// <summary>
    /// >> GearSchedulerConstants
    /// </summary>
    public sealed class GearSchedulerConstants
    {
        
        /// <summary>
        /// >> ReserveThreshold
        ///  Amount of blocks for extra delay used to secure from outdated tasks.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 ReserveThreshold()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x01000000");
            return result;
        }
        
        /// <summary>
        /// >> WaitlistCost
        ///  Cost for storing in waitlist per block.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 WaitlistCost()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U64();
            result.Create("0x6400000000000000");
            return result;
        }
        
        /// <summary>
        /// >> MailboxCost
        ///  Cost for storing in mailbox per block.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 MailboxCost()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U64();
            result.Create("0x6400000000000000");
            return result;
        }
        
        /// <summary>
        /// >> ReservationCost
        ///  Cost for reservation holding.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 ReservationCost()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U64();
            result.Create("0x6400000000000000");
            return result;
        }
        
        /// <summary>
        /// >> DispatchHoldCost
        ///  Cost for reservation holding.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 DispatchHoldCost()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U64();
            result.Create("0x6400000000000000");
            return result;
        }
    }
    
    /// <summary>
    /// >> GearSchedulerErrors
    /// </summary>
    public enum GearSchedulerErrors
    {
        
        /// <summary>
        /// >> DuplicateTask
        /// Occurs when given task already exists in task pool.
        /// </summary>
        DuplicateTask,
        
        /// <summary>
        /// >> TaskNotFound
        /// Occurs when task wasn't found in storage.
        /// </summary>
        TaskNotFound,
    }
}
