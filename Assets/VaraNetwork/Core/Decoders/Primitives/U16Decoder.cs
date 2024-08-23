public class U16Decoder : IDecoder
{
    public object Decode(byte[] data)
    {
        return ScaleDecodingService.Decode<ushort>("u16", data);
    }
}