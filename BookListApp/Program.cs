using BookListApp.Components;
using BookListApp.Controller;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Razor-Komponenten mit interaktivem Servermodus hinzufügen
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<ControllerService>();
// builder.Services.AddSingleton<BookCsvService>();
builder.Services.AddHttpClient<BookSupabaseService>();


var app = builder.Build();

// Fehlerbehandlung und HTTPS
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// App-Komponente als Root-Komponente einbinden
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// === Browser automatisch öffnen, nur wenn nicht über Visual Studio ===
if (!Debugger.IsAttached) 
{
    var url = "http://localhost:5010";
    try
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true
        });
    }
    catch
    {
    }
}

app.Run();
