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


namespace Substrate.Vara.NET.NetApiExt.Generated.Model.sp_runtime
{
    
    
    /// <summary>
    /// >> 287 - Composite[sp_runtime.DispatchErrorWithPostInfo]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class DispatchErrorWithPostInfo : BaseType
    {
        
        /// <summary>
        /// >> post_info
        /// </summary>
        public Substrate.Vara.NET.NetApiExt.Generated.Model.frame_support.dispatch.PostDispatchInfo PostInfo { get; set; }
        /// <summary>
        /// >> error
        /// </summary>
        public Substrate.Vara.NET.NetApiExt.Generated.Model.sp_runtime.EnumDispatchError Error { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "DispatchErrorWithPostInfo";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(PostInfo.Encode());
            result.AddRange(Error.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            PostInfo = new Substrate.Vara.NET.NetApiExt.Generated.Model.frame_support.dispatch.PostDispatchInfo();
            PostInfo.Decode(byteArray, ref p);
            Error = new Substrate.Vara.NET.NetApiExt.Generated.Model.sp_runtime.EnumDispatchError();
            Error.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
