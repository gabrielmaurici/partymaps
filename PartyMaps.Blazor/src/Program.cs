using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PartyMaps.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddOidcAuthentication(options =>
{
    options.ProviderOptions.Authority = "https://accounts.google.com/";
    options.ProviderOptions.ClientId = "";
    options.ProviderOptions.RedirectUri = "http://localhost:8000/authentication/login-callback";
    options.ProviderOptions.PostLogoutRedirectUri = "http://localhost:8000/authentication/logout-callback";
    options.ProviderOptions.ResponseType = "id_token";
});

await builder.Build().RunAsync();
