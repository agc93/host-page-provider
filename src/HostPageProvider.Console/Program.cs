// See https://aka.ms/new-console-template for more information

using HostPageProvider;

Console.WriteLine("Hello, World!");
var builder = new VirtualPageBuilder()
    .AddScript("_lib/js/jquery-3.3.1.slim.min.js")
    .AddDefaultErrorUi()
    .AddStylesheet("_content/Blazorise/blazorise.css")
    .SetAppElementId("app2")
    .SetTitle("Blazor app");

var pprovider = new VirtualPageProvider(b =>
{
    b.AddScript("_lib/js/jquery-3.3.1.slim.min.js")
        .AddDefaultErrorUi()
        .AddStylesheet("_content/Blazorise/blazorise.css")
        .SetAppElementId("app2")
        .SetTitle("Blazor app");
});

var config = builder.Build();
var provider = new VirtualPageProvider(config);
