using Microsoft.AspNetCore.ResponseCompression;
using BlazorSignalRApp.Hubs;
using BlazorSignalRApp.Components;
using BlazorSignalRApp.Modules;
using Blazored.SessionStorage; // Importa Blazored.SessionStorage para usar el servicio

var builder = WebApplication.CreateBuilder(args);

// Agrega el servicio de Blazored.SessionStorage
builder.Services.AddBlazoredSessionStorage();

builder.Services.AddSingleton<UserRepository>();  // Registrar UserRepository como un servicio singleton
builder.Services.AddSingleton<AuthService>();      // Registrar AuthService como un servicio singleton

// Agrega servicios para Razor Components e Interactive Server Components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
          new[] { "application/octet-stream" });
});

var app = builder.Build();

// Configuración del pipeline de HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseResponseCompression();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapHub<ChatHub>("/chathub");

app.Run();
