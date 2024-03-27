using NotesApp.Domain.NoteAggregate;
using Xunit;

namespace NotesApp.UnitTests.Domain.NoteAggregate;

public class NoteConstructor
{
  private const string TestTitle = "test title";
  private Note? _testNote;

  private static Note CreateContributor() => new(TestTitle);

  [Fact]
  public void InitializesName()
  {
    _testNote = CreateContributor();

    Assert.Equal(TestTitle, _testNote.Title);
  }
}
