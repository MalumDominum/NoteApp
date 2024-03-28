using Ardalis.Specification;

namespace NotesApp.Domain.NoteAggregate.Specifications;

public sealed class NoteSearchSpec : Specification<Note>
{
  public NoteSearchSpec(string searchValue)
  {
    Query.Where(note => note.Title.Contains(searchValue)
                        || note.Content.Contains(searchValue))
         .OrderByDescending(note => note.CreatedAt);
  }
}
