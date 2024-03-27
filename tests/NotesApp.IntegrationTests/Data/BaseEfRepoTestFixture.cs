using NotesApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NotesApp.Domain.NoteAggregate;

namespace NotesApp.IntegrationTests.Data;

public abstract class BaseEfRepoTestFixture
{
  protected AppDbContext DbContext;

  protected BaseEfRepoTestFixture()
  {
    var options = CreateNewContextOptions();

    DbContext = new AppDbContext(options);
  }

  protected static DbContextOptions<AppDbContext> CreateNewContextOptions()
  {
    // Create a fresh service provider, and therefore a fresh
    // InMemory database instance.
    var serviceProvider = new ServiceCollection()
        .AddEntityFrameworkInMemoryDatabase()
        .BuildServiceProvider();

    // Create a new options instance telling the context to use an
    // InMemory database and the new service provider.
    var builder = new DbContextOptionsBuilder<AppDbContext>();
    builder.UseInMemoryDatabase("cleanarchitecture")
           .UseInternalServiceProvider(serviceProvider);

    return builder.Options;
  }

  protected EfRepository<Note> GetRepository()
  {
    return new EfRepository<Note>(DbContext);
  }
}
