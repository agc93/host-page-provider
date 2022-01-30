namespace HostPageProvider;

public class VirtualPageConfiguration
{
    internal VirtualPageConfiguration() {
        
    }
    public string? Title { get; set; }
    public List<string> Stylesheets { get; } = new();
    public List<string> ScriptLinks { get; } = new();
    public List<string> Elements { get; } = new();
    public List<KeyValuePair<string, IEnumerable<string>>> RawStyles { get; } = new();
    public List<KeyValuePair<string, string>> RawScripts { get; } = new();
    public string AppElementId { get; set; } = "app";
    public string BasePath { get; set; } = "/";
    public string PageFilePath { get; set; } = "index.html";
}