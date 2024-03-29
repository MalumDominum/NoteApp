using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NotesApp.Domain.NoteAggregate;

namespace NotesApp.Infrastructure.Data;

public static class SeedData
{
  public static readonly Note Note1 = new("Shopping list", 
    "1. Eggs\r\n2. Bread\r\n3. Milk\r\n4. Apples\r\n5. Chicken breasts" +
    "\r\n6. Spinach\r\n7. Pasta\r\n8. Tomatoes");
  public static readonly Note Note2 = new("Plans for tomorrow");

  public static void Initialize(IServiceProvider serviceProvider)
  {
    using var dbContext = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

    if (dbContext.Notes.Any()) return;
    PopulateTestData(dbContext);
  }
  
  public static void PopulateTestData(AppDbContext dbContext)
  {
    dbContext.Notes.Add(Note1);
    dbContext.Notes.Add(Note2);

    dbContext.SaveChanges();
  }
}
