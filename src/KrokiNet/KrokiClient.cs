using System.IO;
using System.Text;

namespace KrokiNet;

public class KrokiClient(HttpClient httpClient) : IKrokiClient
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<byte[]> ConvertAsync(KrokiArguments args)
    {
        var url = $"{args.SourceType.ToString().ToLower()}/{args.OutputType.ToString().ToLower()}";
        using StringContent content = new(args.Source, Encoding.UTF8, "text/plain");
        using HttpResponseMessage response = await _httpClient.PostAsync(url, content);

        response.EnsureSuccessStatusCode();

        var stream = await response.Content.ReadAsStreamAsync();
        byte[] bytes;
        using (var binaryReader = new BinaryReader(stream))
        {
            bytes = binaryReader.ReadBytes((int)stream.Length);
        }
        return bytes;
    }
}
