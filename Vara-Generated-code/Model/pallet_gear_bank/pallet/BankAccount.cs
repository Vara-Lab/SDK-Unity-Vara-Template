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


namespace Substrate.Vara.NET.NetApiExt.Generated.Model.pallet_gear_bank.pallet
{
    
    
    /// <summary>
    /// >> 611 - Composite[pallet_gear_bank.pallet.BankAccount]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class BankAccount : BaseType
    {
        
        /// <summary>
        /// >> gas
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Gas { get; set; }
        /// <summary>
        /// >> value
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Value { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "BankAccount";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Gas.Encode());
            result.AddRange(Value.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Gas = new Substrate.NetApi.Model.Types.Primitive.U128();
            Gas.Decode(byteArray, ref p);
            Value = new Substrate.NetApi.Model.Types.Primitive.U128();
            Value.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
