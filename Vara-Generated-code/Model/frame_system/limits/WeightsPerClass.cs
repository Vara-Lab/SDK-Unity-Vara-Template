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


namespace Substrate.Vara.NET.NetApiExt.Generated.Model.frame_system.limits
{
    
    
    /// <summary>
    /// >> 344 - Composite[frame_system.limits.WeightsPerClass]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class WeightsPerClass : BaseType
    {
        
        /// <summary>
        /// >> base_extrinsic
        /// </summary>
        public Substrate.Vara.NET.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight BaseExtrinsic { get; set; }
        /// <summary>
        /// >> max_extrinsic
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.Vara.NET.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight> MaxExtrinsic { get; set; }
        /// <summary>
        /// >> max_total
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.Vara.NET.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight> MaxTotal { get; set; }
        /// <summary>
        /// >> reserved
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.Vara.NET.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight> Reserved { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "WeightsPerClass";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(BaseExtrinsic.Encode());
            result.AddRange(MaxExtrinsic.Encode());
            result.AddRange(MaxTotal.Encode());
            result.AddRange(Reserved.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            BaseExtrinsic = new Substrate.Vara.NET.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight();
            BaseExtrinsic.Decode(byteArray, ref p);
            MaxExtrinsic = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.Vara.NET.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight>();
            MaxExtrinsic.Decode(byteArray, ref p);
            MaxTotal = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.Vara.NET.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight>();
            MaxTotal.Decode(byteArray, ref p);
            Reserved = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.Vara.NET.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight>();
            Reserved.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
