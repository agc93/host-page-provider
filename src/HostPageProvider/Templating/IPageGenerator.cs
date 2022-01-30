namespace HostPageProvider.Templating;

internal interface IPageGenerator
{
    internal string GeneratePage(VirtualPageConfiguration pageConfiguration);
}