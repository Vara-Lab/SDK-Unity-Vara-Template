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


namespace Substrate.Vara.NET.NetApiExt.Generated.Model.sp_session
{
    
    
    /// <summary>
    /// >> 76 - Composite[sp_session.MembershipProof]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class MembershipProof : BaseType
    {
        
        /// <summary>
        /// >> session
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Session { get; set; }
        /// <summary>
        /// >> trie_nodes
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>> TrieNodes { get; set; }
        /// <summary>
        /// >> validator_count
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 ValidatorCount { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "MembershipProof";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Session.Encode());
            result.AddRange(TrieNodes.Encode());
            result.AddRange(ValidatorCount.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Session = new Substrate.NetApi.Model.Types.Primitive.U32();
            Session.Decode(byteArray, ref p);
            TrieNodes = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>();
            TrieNodes.Decode(byteArray, ref p);
            ValidatorCount = new Substrate.NetApi.Model.Types.Primitive.U32();
            ValidatorCount.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
