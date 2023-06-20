using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PartyMaps;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
    
builder.Services.AddOidcAuthentication(options => {
    options.ProviderOptions.Authority = "https://accounts.google.com/";
    options.ProviderOptions.ClientId = "";
    options.ProviderOptions.RedirectUri = "https://inritus.serveo.net/authentication/login-callback";
    options.ProviderOptions.PostLogoutRedirectUri = "https://inritus.serveo.net/authentication/logout-callback";
    options.ProviderOptions.ResponseType = "id_token";
    // builder.Configuration.Bind("Local", options.ProviderOptions);
});

await builder.Build().RunAsync();