using NotesApp.Domain.NoteAggregate;
using Xunit;

namespace NotesApp.IntegrationTests.Data;

public class EfRepositoryAdd : BaseEfRepoTestFixture
{
  [Fact]
  public async Task AddsContributorAndSetsId()
  {
    const string testNoteTitle = "test note";
    var repository = GetRepository();
    var note = new Note(testNoteTitle);

    await repository.AddAsync(note);

    var newNote = (await repository.ListAsync()).FirstOrDefault();

    Assert.Equal(testNoteTitle, newNote?.Title);
    Assert.True(newNote?.Id > 0);
  }
}
