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


namespace Substrate.Vara.NET.NetApiExt.Generated.Model.gear_core.reservation
{
    
    
    /// <summary>
    /// >> 582 - Composite[gear_core.reservation.ReservationNonce]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ReservationNonce : BaseType
    {
        
        /// <summary>
        /// >> value
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 Value { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "ReservationNonce";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Value.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Value = new Substrate.NetApi.Model.Types.Primitive.U64();
            Value.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
