public class U64Decoder : IDecoder
{
    public object Decode(byte[] data)
    {
        return ScaleDecodingService.Decode<ulong>("u64", data);
    }
}