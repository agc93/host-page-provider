# HostPageProvider

An `IFileProvider` implementation for generating an app host page at runtime. 

This library is primarily intended for use with WebView2/WPF/Blazor Hybrid scenarios. In short, it always annoyed me that even separating components into RCLs, the host app would usually end up with an additional `index.html` page.

Because my brain is a weird place and OCD does things to people, I made this `IFileProvider` implementation that can generate an `index.html` based on a fluent API then provide that page to the app when it runs, no "real" `index.html` required.

## FAQ

#### Is this a good idea?

No

#### Does it make much sense?

Also no.

#### Is this materially any better than just including the HTML file in your project?

Yes. Just kidding, no.