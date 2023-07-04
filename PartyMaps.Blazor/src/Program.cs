using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PartyMaps.Blazor;
using src.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5000") });

builder.Services.AddScoped<IntegrationPartyMapsApiService>();

builder.Services.AddOidcAuthentication(options =>
{
    options.ProviderOptions.Authority = "https://accounts.google.com/";
    options.ProviderOptions.ClientId = "649575633025-pltlppv6mh2onggkumms6n44iul9umsa.apps.googleusercontent.com";
    options.ProviderOptions.RedirectUri = "http://localhost:8000/authentication/login-callback";
    options.ProviderOptions.PostLogoutRedirectUri = "http://localhost:8000/authentication/logout-callback";
    options.ProviderOptions.ResponseType = "id_token";
});

await builder.Build().RunAsync();
