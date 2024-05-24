using System.Reflection;
using Blazored.SessionStorage;
using Blazored.Toast;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PortalGalaxy.Client;
using PortalGalaxy.Client.Auth;
using Scrutor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("BackendUrl")!) });

builder.Services.AddBlazoredSessionStorage();
builder.Services.AddBlazoredToast();
builder.Services.AddSweetAlert2();
builder.Services.AddBlazorBootstrap();

// Registramos las dependencias de Repositories y Services (SCRUTOR)
builder.Services.Scan(selector => selector
    .FromAssemblies(Assembly.GetExecutingAssembly())
    .AddClasses(false)
    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
    .AsMatchingInterface()
    .WithScopedLifetime());

// Habilitamos el contexto de seguridad de Blazor
builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationService>();
builder.Services.AddAuthorizationCore();
await builder.Build().RunAsync();
