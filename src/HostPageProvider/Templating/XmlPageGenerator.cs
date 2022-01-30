using System.Text;
using System.Xml.Linq;

namespace HostPageProvider.Templating;

internal class XmlPageGenerator : IPageGenerator
{
    string IPageGenerator.GeneratePage(VirtualPageConfiguration pageConfiguration) {
        var d = new System.Xml.Linq.XDocument();
        d.AddFirst(new  System.Xml.Linq.XDocumentType("html", null, null, null));

        var htmlElement = new System.Xml.Linq.XElement("html");
        d.Add(htmlElement);

        var meta = new XElement("meta", new XAttribute("charset", "utf-8"));
        var metaView = new XElement("meta", new XAttribute("name", "viewport"),
            new XAttribute("content", "width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no"));
        var title = new XElement("title", pageConfiguration.Title ?? "Razor app");
        var baseHref = new XElement("base", new XAttribute("href", pageConfiguration.BasePath));
        var stylesheets = pageConfiguration.Stylesheets.Select(ss =>
            new XElement("link", new XAttribute("rel", "stylesheet"), new XAttribute("href", ss)));
        var styles = new XElement("style", pageConfiguration.RawStyles.ToStyles());
        var headElement = new XElement("head", meta, metaView, title, baseHref, stylesheets, styles);
        htmlElement.Add(headElement);

        var bodyElement = new System.Xml.Linq.XElement("body");
        var appElement = new XElement("div", new XAttribute("id", pageConfiguration.AppElementId), string.Empty);
        bodyElement.Add(appElement);
        foreach (var pageElement in pageConfiguration.Elements) {
            bodyElement.Add(XElement.Parse(pageElement));
        }

        foreach (var scriptLink in pageConfiguration.ScriptLinks) {
            var scriptElement = new XElement("script", new XAttribute("src", scriptLink), string.Empty);
            bodyElement.Add(scriptElement);
        }

        foreach (var rawScript in pageConfiguration.RawScripts) {
            var scriptElement = new XElement("script", new XAttribute("type", rawScript.Key), rawScript.Value);
            bodyElement.Add(scriptElement);
        }
        htmlElement.Add(bodyElement);
        
        var settings = new System.Xml.XmlWriterSettings {
            OmitXmlDeclaration = true,
            Indent = true,
        };

        var sw = new Utf8StringWriter();
        var w = System.Xml.XmlWriter.Create(sw, settings);

        d.Save(w);
        w.Close();
        return sw.ToString();
    }
}

public sealed class Utf8StringWriter : StringWriter
{
    public override Encoding Encoding => Encoding.UTF8;
}