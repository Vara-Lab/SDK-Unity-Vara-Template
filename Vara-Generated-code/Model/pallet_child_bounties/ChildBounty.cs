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


namespace Substrate.Vara.NET.NetApiExt.Generated.Model.pallet_child_bounties
{
    
    
    /// <summary>
    /// >> 528 - Composite[pallet_child_bounties.ChildBounty]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ChildBounty : BaseType
    {
        
        /// <summary>
        /// >> parent_bounty
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 ParentBounty { get; set; }
        /// <summary>
        /// >> value
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Value { get; set; }
        /// <summary>
        /// >> fee
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Fee { get; set; }
        /// <summary>
        /// >> curator_deposit
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 CuratorDeposit { get; set; }
        /// <summary>
        /// >> status
        /// </summary>
        public Substrate.Vara.NET.NetApiExt.Generated.Model.pallet_child_bounties.EnumChildBountyStatus Status { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "ChildBounty";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(ParentBounty.Encode());
            result.AddRange(Value.Encode());
            result.AddRange(Fee.Encode());
            result.AddRange(CuratorDeposit.Encode());
            result.AddRange(Status.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            ParentBounty = new Substrate.NetApi.Model.Types.Primitive.U32();
            ParentBounty.Decode(byteArray, ref p);
            Value = new Substrate.NetApi.Model.Types.Primitive.U128();
            Value.Decode(byteArray, ref p);
            Fee = new Substrate.NetApi.Model.Types.Primitive.U128();
            Fee.Decode(byteArray, ref p);
            CuratorDeposit = new Substrate.NetApi.Model.Types.Primitive.U128();
            CuratorDeposit.Decode(byteArray, ref p);
            Status = new Substrate.Vara.NET.NetApiExt.Generated.Model.pallet_child_bounties.EnumChildBountyStatus();
            Status.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
