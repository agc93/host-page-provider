using System.Collections;
using Microsoft.Extensions.FileProviders;

namespace HostPageProvider;

// This is never used by BlazorWebView or WebViewManager
public sealed class VirtualDirectory : IDirectoryContents
{
    private readonly Dictionary<string,string> _sourceFiles;

    public VirtualDirectory(Dictionary<string, string> matchingFiles) {
        _sourceFiles = matchingFiles;
    }

    public bool Exists => _sourceFiles.Any();

    public IEnumerator<IFileInfo> GetEnumerator()
        => _sourceFiles.Select(sf => new VirtualFile(sf.Key, sf.Value)).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => _sourceFiles.Select(sf => new VirtualFile(sf.Key, sf.Value)).GetEnumerator();
}