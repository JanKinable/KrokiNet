namespace KrokiNet;

public class KrokiArguments
{
    private KrokiOutputType _outputType;

    public required string Source { get; set; }
    public required KrokiDiagramType SourceType { get; set; }

    public KrokiOutputType OutputType
    {
        get
        {
            return _outputType == KrokiOutputType.None ? KrokiOutputType.SVG : _outputType;
        }
        set
        {
            if(!SupportedOutputTypes.IsSupported(SourceType, value))
            {
                throw new InvalidOperationException($"Output type {value} is not supported for sourcetype {SourceType}");
            }
            _outputType = value;
        }
    }
}

public static class SupportedOutputTypes
{
    private static readonly Dictionary<KrokiDiagramType, KrokiOutputType[]> _matrix = new Dictionary<KrokiDiagramType, KrokiOutputType[]>
    {
        { KrokiDiagramType.BlockDiag, new KrokiOutputType[] { KrokiOutputType.SVG, KrokiOutputType.PNG, KrokiOutputType.PDF} },
        { KrokiDiagramType.BPMN, new KrokiOutputType[] { KrokiOutputType.SVG } },
        { KrokiDiagramType.Bytefield, new KrokiOutputType[] {KrokiOutputType.SVG} },
        { KrokiDiagramType.SeqDiag, new KrokiOutputType[] {KrokiOutputType.SVG, KrokiOutputType.PNG, KrokiOutputType.PDF } },
        { KrokiDiagramType.ActDiag, new KrokiOutputType[] {KrokiOutputType.SVG, KrokiOutputType.PNG, KrokiOutputType.PDF } },
        { KrokiDiagramType.NwDiag, new KrokiOutputType[] {KrokiOutputType.SVG, KrokiOutputType.PNG, KrokiOutputType.PDF } },
        { KrokiDiagramType.PacketDiag, new KrokiOutputType[] {KrokiOutputType.SVG, KrokiOutputType.PNG, KrokiOutputType.PDF } },
        { KrokiDiagramType.RackDiag, new KrokiOutputType[] {KrokiOutputType.SVG, KrokiOutputType.PNG, KrokiOutputType.PDF } },
        { KrokiDiagramType.C4PlantUml, new KrokiOutputType[] {KrokiOutputType.SVG, KrokiOutputType.PNG, KrokiOutputType.PDF, KrokiOutputType.TXT, KrokiOutputType.Base64 } },
        { KrokiDiagramType.D2, new KrokiOutputType[] {KrokiOutputType.SVG} },
        { KrokiDiagramType.Dbml, new KrokiOutputType[] {KrokiOutputType.SVG} },
        { KrokiDiagramType.Ditaa, new KrokiOutputType[] {KrokiOutputType.SVG, KrokiOutputType.PNG } },
        { KrokiDiagramType.Erd, new KrokiOutputType[] {KrokiOutputType.SVG, KrokiOutputType.PNG, KrokiOutputType.JPG, KrokiOutputType.PDF } },
        { KrokiDiagramType.Excalidraw, new KrokiOutputType[] {KrokiOutputType.SVG} },
        { KrokiDiagramType.GraphViz, new KrokiOutputType[] {KrokiOutputType.SVG, KrokiOutputType.PNG, KrokiOutputType.JPG } },
        { KrokiDiagramType.Mermaid, new KrokiOutputType[] {KrokiOutputType.SVG, KrokiOutputType.PNG } },
        { KrokiDiagramType.Nomnoml, new KrokiOutputType[] {KrokiOutputType.SVG} },
        { KrokiDiagramType.Pikchr, new KrokiOutputType[] {KrokiOutputType.SVG} },
        { KrokiDiagramType.PlantUml, new KrokiOutputType[] {KrokiOutputType.SVG, KrokiOutputType.PNG, KrokiOutputType.PDF, KrokiOutputType.TXT, KrokiOutputType.Base64 } },
        { KrokiDiagramType.Structurizr, new KrokiOutputType[] {KrokiOutputType.SVG, KrokiOutputType.PNG, KrokiOutputType.PDF, KrokiOutputType.TXT, KrokiOutputType.Base64 } },
        { KrokiDiagramType.Svgbob, new KrokiOutputType[] {KrokiOutputType.SVG} },
        { KrokiDiagramType.Symbolator, new KrokiOutputType[] {KrokiOutputType.SVG} },
        { KrokiDiagramType.TikZ, new KrokiOutputType[] {KrokiOutputType.SVG, KrokiOutputType.PNG, KrokiOutputType.JPG, KrokiOutputType.PDF } },
        { KrokiDiagramType.UMlet, new KrokiOutputType[] {KrokiOutputType.SVG, KrokiOutputType.PNG, KrokiOutputType.JPG } },
        { KrokiDiagramType.Vega, new KrokiOutputType[] {KrokiOutputType.SVG, KrokiOutputType.PNG, KrokiOutputType.PDF } },
        { KrokiDiagramType.VegaLite, new KrokiOutputType[] {KrokiOutputType.SVG, KrokiOutputType.PNG, KrokiOutputType.PDF } },
        { KrokiDiagramType.WaveDrom, new KrokiOutputType[] {KrokiOutputType.SVG} },
        { KrokiDiagramType.WireViz, new KrokiOutputType[] {KrokiOutputType.SVG, KrokiOutputType.PNG } }
    };

    public static bool IsSupported(KrokiDiagramType diagramType, KrokiOutputType outputType) 
        => _matrix[diagramType].Contains(outputType);
}
