using System;

public static class DecoderFactory
{
    public static IDecoder GetDecoder(string type)
    {
        return type switch
        {
            "str" => new StringDecoder(),
            "vec struct { actor_id, str }" => new VecActorIdStrDecoder(),
            "[u8;32]" => new ActorIdDecoder(),
            "u8" => new U8Decoder(),
            "u16" => new U16Decoder(),
            "u32" => new U32Decoder(),
            "u64" => new U64Decoder(),
            "u128" => new U128Decoder(),
            "i8" => new I8Decoder(),
            "i16" => new I16Decoder(),
            "i32" => new I32Decoder(),
            "i64" => new I64Decoder(),
            _ => throw new NotSupportedException($"The type '{type}' is not supported for decoding.")
        };
    }
}
