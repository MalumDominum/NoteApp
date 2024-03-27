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
}
