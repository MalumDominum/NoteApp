using Microsoft.EntityFrameworkCore;
using NotesApp.Domain.NoteAggregate;
using Xunit;

namespace NotesApp.IntegrationTests.Data;

public class EfRepositoryUpdate : BaseEfRepoTestFixture
{
  [Fact]
  public async Task UpdatesItemAfterAddingIt()
  {
    // add a note
    var repository = GetRepository();
    var initialTitle = Guid.NewGuid().ToString();
    var note = new Note(initialTitle);

    await repository.AddAsync(note);

    // detach the item so we get a different instance
    DbContext.Entry(note).State = EntityState.Detached;

    // fetch the item and update its title
    var newContributor = (await repository.ListAsync())
        .FirstOrDefault(n => n.Title == initialTitle);
    if (newContributor == null)
    {
      Assert.NotNull(newContributor);
      return;
    }
    Assert.NotSame(note, newContributor);
    var newTitle = Guid.NewGuid().ToString();
    newContributor.UpdateTitle(newTitle);

    // Update the item
    await repository.UpdateAsync(newContributor);

    // Fetch the updated item
    var updatedItem = (await repository.ListAsync())
        .FirstOrDefault(n => n.Title == newTitle);

    Assert.NotNull(updatedItem);
    Assert.NotEqual(note.Title, updatedItem?.Title);
    Assert.Equal(note.Content, updatedItem?.Content);
    Assert.Equal(newContributor.Id, updatedItem?.Id);
  }
}
