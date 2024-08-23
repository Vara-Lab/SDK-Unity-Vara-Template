public class I8Decoder : IDecoder
{
    public object Decode(byte[] data)
    {
        return ScaleDecodingService.Decode<sbyte>("i8", data);
    }
}