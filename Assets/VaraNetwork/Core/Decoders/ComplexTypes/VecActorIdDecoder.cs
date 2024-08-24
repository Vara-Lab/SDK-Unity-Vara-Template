using System.Collections.Generic;
public class VecActorIdDecoder : IDecoder
{
    public object Decode(byte[] data)
    {
        return ScaleDecodingService.Decode<List<string>>("Vec<[u8;32]>", data);
    }
}