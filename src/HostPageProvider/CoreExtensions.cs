namespace HostPageProvider;

public static class CoreExtensions
{
    internal static string StripPrefix(this string text, string prefix) {
        return text.StartsWith(prefix) ? text[prefix.Length..] : text;
    }
}