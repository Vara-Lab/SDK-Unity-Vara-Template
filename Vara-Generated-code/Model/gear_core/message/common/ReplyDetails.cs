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


namespace Substrate.Vara.NET.NetApiExt.Generated.Model.gear_core.message.common
{
    
    
    /// <summary>
    /// >> 309 - Composite[gear_core.message.common.ReplyDetails]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ReplyDetails : BaseType
    {
        
        /// <summary>
        /// >> to
        /// </summary>
        public Substrate.Vara.NET.NetApiExt.Generated.Model.gear_core.ids.MessageId To { get; set; }
        /// <summary>
        /// >> code
        /// </summary>
        public Substrate.Vara.NET.NetApiExt.Generated.Model.gear_core_errors.simple.EnumReplyCode Code { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "ReplyDetails";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(To.Encode());
            result.AddRange(Code.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            To = new Substrate.Vara.NET.NetApiExt.Generated.Model.gear_core.ids.MessageId();
            To.Decode(byteArray, ref p);
            Code = new Substrate.Vara.NET.NetApiExt.Generated.Model.gear_core_errors.simple.EnumReplyCode();
            Code.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
