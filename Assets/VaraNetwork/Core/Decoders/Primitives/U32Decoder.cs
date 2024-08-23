public class U32Decoder : IDecoder
{
    public object Decode(byte[] data)
    {
        return ScaleDecodingService.Decode<uint>("u32", data);
    }
}