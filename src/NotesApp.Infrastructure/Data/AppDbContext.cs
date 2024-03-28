using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NotesApp.Domain.NoteAggregate;

namespace NotesApp.Infrastructure.Data;
public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  public DbSet<Note> Notes => Set<Note>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
  }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new()) =>
    await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

  public override int SaveChanges() => SaveChangesAsync().GetAwaiter().GetResult();
}
