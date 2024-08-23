public class ActorIdDecoder : IDecoder
{
    public object Decode(byte[] data)
    {
        return ScaleDecodingService.Decode<string>("[u8;32]", data);
    }
}