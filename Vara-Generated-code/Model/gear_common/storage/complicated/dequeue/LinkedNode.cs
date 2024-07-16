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


namespace Substrate.Vara.NET.NetApiExt.Generated.Model.gear_common.storage.complicated.dequeue
{
    
    
    /// <summary>
    /// >> 568 - Composite[gear_common.storage.complicated.dequeue.LinkedNode]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class LinkedNode : BaseType
    {
        
        /// <summary>
        /// >> next
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.Vara.NET.NetApiExt.Generated.Model.gear_core.ids.MessageId> Next { get; set; }
        /// <summary>
        /// >> value
        /// </summary>
        public Substrate.Vara.NET.NetApiExt.Generated.Model.gear_core.message.stored.StoredDispatch Value { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "LinkedNode";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Next.Encode());
            result.AddRange(Value.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Next = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.Vara.NET.NetApiExt.Generated.Model.gear_core.ids.MessageId>();
            Next.Decode(byteArray, ref p);
            Value = new Substrate.Vara.NET.NetApiExt.Generated.Model.gear_core.message.stored.StoredDispatch();
            Value.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
