using System.Collections.Generic;
public class VecActorIdStrDecoder : IDecoder
{
    public object Decode(byte[] data)
    {
        return ScaleDecodingService.Decode<List<(string, string)>>("vec struct { actor_id, str }", data);
    }
}