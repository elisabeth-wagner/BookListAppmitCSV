using BookListApp.Components;
using BookListApp.Controller;

var builder = WebApplication.CreateBuilder(args);

// Razor-Komponenten mit interaktivem Servermodus hinzufügen
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<ControllerService>();

builder.Services.AddSingleton<BookCsvService>();


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

app.Run();

