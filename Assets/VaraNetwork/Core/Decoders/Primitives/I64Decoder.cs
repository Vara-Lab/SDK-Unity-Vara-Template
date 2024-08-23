public class I64Decoder : IDecoder
{
    public object Decode(byte[] data)
    {
        return ScaleDecodingService.Decode<long>("i64", data);
    }
}