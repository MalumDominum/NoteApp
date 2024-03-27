using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace NotesApp.Application;
public static class ApplicationDiModule
{
  public static IServiceCollection AddApplication(this IServiceCollection services, ILogger logger)
  {
    services.AddMediatR(config =>
      config.RegisterServicesFromAssembly(typeof(ApplicationDiModule).Assembly));

    logger.LogInformation("{Project} services registered", "Application");

    return services;
  }
}
