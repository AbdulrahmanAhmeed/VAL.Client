using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VAL.Client;
using VAL.Client.Handlers;
using VAL.Client.Providers;
using VAL.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Add Blazored LocalStorage first
builder.Services.AddBlazoredLocalStorage();

// Register the AuthorizationMessageHandler
builder.Services.AddScoped<AuthorizationMessageHandler>();

// Configure HttpClient with the handler
builder.Services.AddScoped(sp =>
{
    var handler = sp.GetRequiredService<AuthorizationMessageHandler>();
    handler.InnerHandler = new HttpClientHandler();

    var httpClient = new HttpClient(handler)
    {
        BaseAddress = new Uri("https://gigapp.runasp.net")
    };

    return httpClient;
});

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IDataObjectService, DataObjectService>();
builder.Services.AddScoped<ILegacySystemService, LegacySystemService>();
builder.Services.AddScoped<IDataObjectColumnService, DataObjectColumnService>();
builder.Services.AddScoped<IScreenLoadLogService, ScreenLoadLogService>();
builder.Services.AddScoped<IZRefcolumnColumnOrdinalPositionCodeService, ZRefcolumnColumnOrdinalPositionCodeService>();
builder.Services.AddScoped<IZRefcolumnDataTypeService, ZRefcolumnDataTypeService>();
builder.Services.AddScoped<IZRefcolumnYesNoUnknownNaService, ZRefcolumnYesNoUnknownNaService>();

await builder.Build().RunAsync();
