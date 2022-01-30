using Microsoft.Extensions.FileProviders;

namespace HostPageProvider;


public class VirtualFile : IFileInfo
{
    private readonly string _filePath;
    private readonly string? _contents;
    private readonly DateTimeOffset _created;

    public VirtualFile(string filePath, string? generatedFileContents) {
        _contents = generatedFileContents;
        _filePath = filePath;
        Exists = string.IsNullOrWhiteSpace(_contents);
        Length = Exists ? _contents?.Length ?? -1 : -1;
        Name = Path.GetFileName(filePath);
        _created = DateTimeOffset.Now;
    }

    public bool Exists { get; }
    public long Length { get; }
    public string PhysicalPath { get; } = null!;
    public string Name { get; }
    public DateTimeOffset LastModified => _created;
    public bool IsDirectory => false;

    public Stream CreateReadStream()
        => new MemoryStream(System.Text.Encoding.UTF8.GetBytes(_contents));
}