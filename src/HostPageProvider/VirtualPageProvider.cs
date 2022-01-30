using HostPageProvider.Templating;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

namespace HostPageProvider;

public class VirtualPageProvider : IFileProvider
{
    private readonly IPageGenerator _generator = new XmlPageGenerator();
    private readonly VirtualPageProviderConfiguration _config = new ();
    private Dictionary<string, string> GeneratedFiles { get; } = new();

    public VirtualPageProvider(params Action<VirtualPageBuilder>[] configFunc) {
        foreach (var func in configFunc) {
            var config = new VirtualPageBuilder();
            func(config);
            var pageConfig = config.Build();
            GeneratedFiles[pageConfig.PageFilePath] = _generator.GeneratePage(pageConfig);
        }
    }
    public VirtualPageProvider(params VirtualPageConfiguration[] pageConfigurations) {
        foreach (var pageConfig in pageConfigurations) {
            GeneratedFiles[pageConfig.PageFilePath] = _generator.GeneratePage(pageConfig);
        }
    }
    public VirtualPageProvider(VirtualPageProviderConfiguration config, params VirtualPageConfiguration[] pageConfigurations) : this(pageConfigurations) {
        _config = config;
    }
    public IFileInfo GetFileInfo(string subpath) {
        var path = Path.Combine(_config.ResourcePrefix ?? string.Empty, subpath.StripPrefix(_config.VirtualRoot ?? string.Empty));
        return new VirtualFile(path, 
            GeneratedFiles.GetValueOrDefault(path));
    }

    public IDirectoryContents GetDirectoryContents(string subpath) {
        var path = Path.Combine(_config.ResourcePrefix ?? string.Empty, subpath.StripPrefix(_config.VirtualRoot ?? string.Empty));
        return new VirtualDirectory(GeneratedFiles.Where(gf => gf.Key.StartsWith(path)).ToDictionary(k => k.Key, v => v.Value));
    }

    public IChangeToken Watch(string filter) => null!;
}