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


namespace Substrate.Vara.NET.NetApiExt.Generated.Model.sp_consensus_slots
{
    
    
    /// <summary>
    /// >> 71 - Composite[sp_consensus_slots.EquivocationProof]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class EquivocationProof : BaseType
    {
        
        /// <summary>
        /// >> offender
        /// </summary>
        public Substrate.Vara.NET.NetApiExt.Generated.Model.sp_consensus_babe.app.Public Offender { get; set; }
        /// <summary>
        /// >> slot
        /// </summary>
        public Substrate.Vara.NET.NetApiExt.Generated.Model.sp_consensus_slots.Slot Slot { get; set; }
        /// <summary>
        /// >> first_header
        /// </summary>
        public Substrate.Vara.NET.NetApiExt.Generated.Model.sp_runtime.generic.header.Header FirstHeader { get; set; }
        /// <summary>
        /// >> second_header
        /// </summary>
        public Substrate.Vara.NET.NetApiExt.Generated.Model.sp_runtime.generic.header.Header SecondHeader { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "EquivocationProof";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Offender.Encode());
            result.AddRange(Slot.Encode());
            result.AddRange(FirstHeader.Encode());
            result.AddRange(SecondHeader.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Offender = new Substrate.Vara.NET.NetApiExt.Generated.Model.sp_consensus_babe.app.Public();
            Offender.Decode(byteArray, ref p);
            Slot = new Substrate.Vara.NET.NetApiExt.Generated.Model.sp_consensus_slots.Slot();
            Slot.Decode(byteArray, ref p);
            FirstHeader = new Substrate.Vara.NET.NetApiExt.Generated.Model.sp_runtime.generic.header.Header();
            FirstHeader.Decode(byteArray, ref p);
            SecondHeader = new Substrate.Vara.NET.NetApiExt.Generated.Model.sp_runtime.generic.header.Header();
            SecondHeader.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
