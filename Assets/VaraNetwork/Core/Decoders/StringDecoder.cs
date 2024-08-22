public class StringDecoder : IDecoder
{
    public object Decode(byte[] data)
    {
        return ScaleDecodingService.Decode<string>("str", data);
    }
}