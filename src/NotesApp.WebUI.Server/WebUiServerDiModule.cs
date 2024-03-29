using NotesApp.Infrastructure.Data;

namespace NotesApp.WebUI.Server;

public static class WebUiServerDiModule
{
  public static IServiceCollection AddWebUiServer(this IServiceCollection services, ILogger logger)
  {
    services.AddRazorComponents()
            .AddInteractiveServerComponents();

    logger.LogInformation("{Project} services registered", "WebUI Server");

    return services;
  }

  public static void CreateAndSeedDatabase(this IHost app)
  {
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;

    try
    {
      var context = services.GetRequiredService<AppDbContext>();
      // Manage Database
      //context.Database.Migrate();
      context.Database.EnsureDeleted();
      context.Database.EnsureCreated();

      SeedData.Initialize(services);
    }
    catch (Exception ex)
    {
      var logger = services.GetRequiredService<ILogger<Program>>();
      logger.LogError(ex, "An error occurred while seeding the DB. {exceptionMessage}", ex.Message);
    }
  }
}
