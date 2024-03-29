using Ardalis.Specification;
using static System.String;

namespace NotesApp.Domain.NoteAggregate.Specifications;

public sealed class NoteSearchSpec : Specification<Note>
{
  public NoteSearchSpec(string? searchValue)
  {
    if (!IsNullOrEmpty(searchValue))
      Query.Where(note => note.Title.ToLower().Contains(searchValue.ToLower()) 
                          || note.Content.ToLower().Contains(searchValue.ToLower()));

    Query.OrderByDescending(note => note.CreatedAt);
  }
}
