using NotesApp.Application;
using NotesApp.Infrastructure;
using NotesApp.WebUI.Server;
using NotesApp.WebUI.Server.Components;
using Serilog;
using Serilog.Extensions.Logging;

var logger = Log.Logger = new LoggerConfiguration()
  .Enrich.FromLogContext()
  .WriteTo.Console()
  .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));
var microsoftLogger = new SerilogLoggerFactory(logger).CreateLogger<Program>();

// Add services from all layers.
builder.Services
  .AddInfrastructure(builder.Configuration, microsoftLogger)
  .AddApplication(microsoftLogger)
  .AddWebUiServer(microsoftLogger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error", createScopeForErrors: true);
  app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.CreateAndSeedDatabase();

app.Run();

// Make the implicit Program.cs class public, so integration tests can reference the correct assembly for host building
public partial class Program
{
}
