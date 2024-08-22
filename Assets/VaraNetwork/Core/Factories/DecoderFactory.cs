using System;

public static class DecoderFactory
{
    public static IDecoder GetDecoder(string type)
    {
        return type switch
        {
            "str" => new StringDecoder(),
            "vec struct { actor_id, str }" => new VecActorIdStrDecoder(),
            // Add more types
            _ => throw new NotSupportedException($"The type '{type}' is not supported for decoding.")
        };
    }
}