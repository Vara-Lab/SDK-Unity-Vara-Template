//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi.Attributes;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.V14;
using System.Collections.Generic;


namespace Substrate.Vara.NET.NetApiExt.Generated.Model.pallet_gear.schedule
{
    
    
    /// <summary>
    /// >> 600 - Composite[pallet_gear.schedule.Schedule]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Schedule : BaseType
    {
        
        /// <summary>
        /// >> limits
        /// </summary>
        public Substrate.Vara.NET.NetApiExt.Generated.Model.pallet_gear.schedule.Limits Limits { get; set; }
        /// <summary>
        /// >> instruction_weights
        /// </summary>
        public Substrate.Vara.NET.NetApiExt.Generated.Model.pallet_gear.schedule.InstructionWeights InstructionWeights { get; set; }
        /// <summary>
        /// >> host_fn_weights
        /// </summary>
        public Substrate.Vara.NET.NetApiExt.Generated.Model.pallet_gear.schedule.HostFnWeights HostFnWeights { get; set; }
        /// <summary>
        /// >> memory_weights
        /// </summary>
        public Substrate.Vara.NET.NetApiExt.Generated.Model.pallet_gear.schedule.MemoryWeights MemoryWeights { get; set; }
        /// <summary>
        /// >> module_instantiation_per_byte
        /// </summary>
        public Substrate.Vara.NET.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight ModuleInstantiationPerByte { get; set; }
        /// <summary>
        /// >> db_write_per_byte
        /// </summary>
        public Substrate.Vara.NET.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight DbWritePerByte { get; set; }
        /// <summary>
        /// >> db_read_per_byte
        /// </summary>
        public Substrate.Vara.NET.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight DbReadPerByte { get; set; }
        /// <summary>
        /// >> code_instrumentation_cost
        /// </summary>
        public Substrate.Vara.NET.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight CodeInstrumentationCost { get; set; }
        /// <summary>
        /// >> code_instrumentation_byte_cost
        /// </summary>
        public Substrate.Vara.NET.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight CodeInstrumentationByteCost { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "Schedule";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Limits.Encode());
            result.AddRange(InstructionWeights.Encode());
            result.AddRange(HostFnWeights.Encode());
            result.AddRange(MemoryWeights.Encode());
            result.AddRange(ModuleInstantiationPerByte.Encode());
            result.AddRange(DbWritePerByte.Encode());
            result.AddRange(DbReadPerByte.Encode());
            result.AddRange(CodeInstrumentationCost.Encode());
            result.AddRange(CodeInstrumentationByteCost.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Limits = new Substrate.Vara.NET.NetApiExt.Generated.Model.pallet_gear.schedule.Limits();
            Limits.Decode(byteArray, ref p);
            InstructionWeights = new Substrate.Vara.NET.NetApiExt.Generated.Model.pallet_gear.schedule.InstructionWeights();
            InstructionWeights.Decode(byteArray, ref p);
            HostFnWeights = new Substrate.Vara.NET.NetApiExt.Generated.Model.pallet_gear.schedule.HostFnWeights();
            HostFnWeights.Decode(byteArray, ref p);
            MemoryWeights = new Substrate.Vara.NET.NetApiExt.Generated.Model.pallet_gear.schedule.MemoryWeights();
            MemoryWeights.Decode(byteArray, ref p);
            ModuleInstantiationPerByte = new Substrate.Vara.NET.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight();
            ModuleInstantiationPerByte.Decode(byteArray, ref p);
            DbWritePerByte = new Substrate.Vara.NET.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight();
            DbWritePerByte.Decode(byteArray, ref p);
            DbReadPerByte = new Substrate.Vara.NET.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight();
            DbReadPerByte.Decode(byteArray, ref p);
            CodeInstrumentationCost = new Substrate.Vara.NET.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight();
            CodeInstrumentationCost.Decode(byteArray, ref p);
            CodeInstrumentationByteCost = new Substrate.Vara.NET.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight();
            CodeInstrumentationByteCost.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}