namespace HostPageProvider;

public class VirtualPageConfiguration
{
    internal VirtualPageConfiguration() {
        
    }
    internal string? Title { get; set; }
    internal List<string> Stylesheets { get; } = new();
    internal List<string> ScriptLinks { get; } = new();
    internal List<string> Elements { get; } = new();
    internal List<KeyValuePair<string, IEnumerable<string>>> RawStyles { get; } = new();
    internal List<KeyValuePair<string, string>> RawScripts { get; } = new();
    internal string AppElementId { get; set; } = "app";
    internal string BasePath { get; set; } = "/";
    internal string PageFilePath { get; set; } = "index.html";
}