using System.Numerics;
public class U128Decoder : IDecoder
{
    public object Decode(byte[] data)
    {
        return ScaleDecodingService.Decode<BigInteger>("u128", data);
    }
}
