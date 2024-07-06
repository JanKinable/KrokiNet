using KrokiNet;

namespace KrokiClient.Demo;

public interface IDemoGraph
{
    Task GenerateImage();
}

public class DemoGraph : IDemoGraph
{
    private readonly IKrokiClient _kroki;

    private readonly string _graph = @"
graph TD
  A[ Anyone ] -->|Can help | B( Go to github.com/yuzutech/kroki )
  B --> C{ How to contribute? }
  C --> D[ Reporting bugs ]
  C --> E[ Sharing ideas ]
  C --> F[ Advocating ]
";

    public DemoGraph(IKrokiClient kroki)
    {
        _kroki = kroki;
    }

    public async Task GenerateImage()
    {
        var args = new KrokiArguments
        {
            Source = _graph,
            SourceType = KrokiDiagramType.Mermaid,
            OutputType = KrokiOutputType.SVG
        };
        
        var bytes = await _kroki.ConvertAsync(args);

        using var fileStream = File.Create(@"C:\Temp\kroki-demo.svg");
        fileStream.Write(bytes);

    }
}
