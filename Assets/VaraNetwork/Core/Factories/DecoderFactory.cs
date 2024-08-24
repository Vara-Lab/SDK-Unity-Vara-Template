using System;

public static class DecoderFactory
{
    public static IDecoder GetDecoder(string type)
    {
        return type switch
        {
            "String" => new StringDecoder(),
            "[u8;32]" => new ActorIdDecoder(),
            "Vec<[u8;32]>" => new VecActorIdDecoder(),
            "vec struct { actor_id, str }" => new VecActorIdStrDecoder(),
            "u8" => new U8Decoder(),
            "u16" => new U16Decoder(),
            "u32" => new U32Decoder(),
            "u64" => new U64Decoder(),
            "u128" => new U128Decoder(),
            "U256" => new U256Decoder(),
            "i8" => new I8Decoder(),
            "i16" => new I16Decoder(),
            "i32" => new I32Decoder(),
            "i64" => new I64Decoder(),
            _ => throw new NotSupportedException($"The type '{type}' is not supported for decoding.")
        };
    }
}
