namespace HostPageProvider;
using HostPageProvider.Templating;

public class VirtualPageBuilder
{
    protected VirtualPageConfiguration Config { get; }= new();

    public VirtualPageBuilder AddStylesheet(string stylesheetHref) {
        Config.Stylesheets.Add(stylesheetHref);
        return this;
    }

    public VirtualPageBuilder AddDefaultErrorUi() {
        Config.Elements.Add(@"
<div id=""blazor-error-ui"">
    An unhandled error has occurred.
    <a href="""" class=""reload"">Reload</a>
    <a class=""dismiss"">🗙</a>
</div>
");
        Config.RawStyles.Add(".valid.modified:not([type=checkbox])", new[] { "outline: 1px solid #26b050;" });
        Config.RawStyles.Add(".invalid", new[] { "outline: 1px solid red;" });
        Config.RawStyles.Add(".validation-message", new[] { "color: red" });
        Config.RawStyles.Add("#blazor-error-ui", new[] {
            "background: lightyellow;",
            "bottom: 0;",
            "box-shadow: 0 -1px 2px rgba(0, 0, 0, 0.2);",
            "display: none;",
            "left: 0;",
            "padding: 0.6rem 1.25rem 0.7rem 1.25rem;",
            "position: fixed;",
            "width: 100%;",
            "z-index: 1000;",
        });
        Config.RawStyles.Add("#blazor-error-ui .dismiss", new [] {
            "cursor: pointer;",
            "position: absolute;",
            "right: 0.75rem;",
            "top: 0.5rem;",
        });
        return this;
    }

    public VirtualPageBuilder AddScript(string scriptHref) {
        Config.ScriptLinks.Add(scriptHref);
        return this;
    }

    public VirtualPageBuilder SetTitle(string title) {
        Config.Title = title;
        return this;
    }

    public VirtualPageBuilder SetAppElementId(string id) {
        Config.AppElementId = id;
        return this;
    }

    public VirtualPageBuilder SetBasePath(string basePath) {
        Config.BasePath = basePath;
        return this;
    }

    public VirtualPageConfiguration Build() => Config;

    public VirtualPageProvider ToProvider(VirtualPageProviderConfiguration? providerConfiguration = null) {
        return providerConfiguration == null ? new VirtualPageProvider(Config) : new VirtualPageProvider(providerConfiguration, Config);
    }
}