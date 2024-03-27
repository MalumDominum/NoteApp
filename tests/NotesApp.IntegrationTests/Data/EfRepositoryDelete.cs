using NotesApp.Domain.NoteAggregate;
using Xunit;

namespace NotesApp.IntegrationTests.Data;

public class EfRepositoryDelete : BaseEfRepoTestFixture
{
  [Fact]
  public async Task DeletesItemAfterAddingIt()
  {
    // add a note
    var repository = GetRepository();
    var initialTitle = Guid.NewGuid().ToString();
    var note = new Note(initialTitle);
    await repository.AddAsync(note);

    // delete the item
    await repository.DeleteAsync(note);

    // verify it's no longer there
    Assert.DoesNotContain(await repository.ListAsync(), 
      n => n.Title == initialTitle);
  }
}
