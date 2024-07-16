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


namespace Substrate.Vara.NET.NetApiExt.Generated.Model.gear_core.message.user
{
    
    
    /// <summary>
    /// >> 586 - Composite[gear_core.message.user.UserStoredMessage]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class UserStoredMessage : BaseType
    {
        
        /// <summary>
        /// >> id
        /// </summary>
        public Substrate.Vara.NET.NetApiExt.Generated.Model.gear_core.ids.MessageId Id { get; set; }
        /// <summary>
        /// >> source
        /// </summary>
        public Substrate.Vara.NET.NetApiExt.Generated.Model.gear_core.ids.ProgramId Source { get; set; }
        /// <summary>
        /// >> destination
        /// </summary>
        public Substrate.Vara.NET.NetApiExt.Generated.Model.gear_core.ids.ProgramId Destination { get; set; }
        /// <summary>
        /// >> payload
        /// </summary>
        public Substrate.Vara.NET.NetApiExt.Generated.Model.gear_core.buffer.LimitedVecT2 Payload { get; set; }
        /// <summary>
        /// >> value
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128> Value { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "UserStoredMessage";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Id.Encode());
            result.AddRange(Source.Encode());
            result.AddRange(Destination.Encode());
            result.AddRange(Payload.Encode());
            result.AddRange(Value.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Id = new Substrate.Vara.NET.NetApiExt.Generated.Model.gear_core.ids.MessageId();
            Id.Decode(byteArray, ref p);
            Source = new Substrate.Vara.NET.NetApiExt.Generated.Model.gear_core.ids.ProgramId();
            Source.Decode(byteArray, ref p);
            Destination = new Substrate.Vara.NET.NetApiExt.Generated.Model.gear_core.ids.ProgramId();
            Destination.Decode(byteArray, ref p);
            Payload = new Substrate.Vara.NET.NetApiExt.Generated.Model.gear_core.buffer.LimitedVecT2();
            Payload.Decode(byteArray, ref p);
            Value = new Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>();
            Value.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
