using System.Linq;
using System.Text;

namespace HostPageProvider.Templating;

public static class TemplatingExtensions
{
    internal static string ToStyles(this Dictionary<string, IEnumerable<string>> styleBlocks) {
        return string.Join(Environment.NewLine, styleBlocks.Select(block =>
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{block.Key} {{");
            sb.AppendJoin(Environment.NewLine, block.Value.Select(v => v.PadLeft(4)));
            sb.AppendLine("}");
            return sb.ToString();
        }));
    }
    
    internal static string ToStyles(this IEnumerable<KeyValuePair<string, IEnumerable<string>>> styleBlocks) {
        return string.Join(Environment.NewLine, styleBlocks.Select(block =>
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{block.Key} {{");
            sb.AppendJoin(Environment.NewLine, block.Value.Select(v => v.PadLeft(4)));
            sb.AppendLine("}");
            return sb.ToString();
        }));
    }

    internal static IList<KeyValuePair<string, IEnumerable<string>>> Add(
        this List<KeyValuePair<string, IEnumerable<string>>> src, string key, IEnumerable<string> value) {
        src.Add(new KeyValuePair<string, IEnumerable<string>>(key, value));
        return src;
    }
}