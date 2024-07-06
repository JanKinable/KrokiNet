namespace KrokiNet;

public interface IKrokiClient
{
    Task<byte[]> ConvertAsync(KrokiArguments args);
} 
