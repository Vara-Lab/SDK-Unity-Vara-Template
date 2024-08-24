using System.Numerics;

public class U256Decoder : IDecoder
{
    public object Decode(byte[] data)
    {
        return ScaleDecodingService.Decode<string>("U256", data);
    }
}
