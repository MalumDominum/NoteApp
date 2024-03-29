using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace NotesApp.Domain.NoteAggregate;

public class Note : EntityBase, IAggregateRoot
{
  public string Title { get; private set; }

  public string Content { get; private set; } = "";

  public DateTime CreatedAt { get; }

  public DateTime? UpdatedAt { get; private set; }

  public Note(string title)
  {
    Title = Guard.Against.NullOrEmpty(title, nameof(title));
    CreatedAt = DateTime.Now;
  }

  public Note(string title, string? content)
  {
    Title = Guard.Against.NullOrEmpty(title, nameof(title));
    Content = content ?? "";
    CreatedAt = DateTime.Now;
  }

  public void UpdateContent(string contentProvided)
  {
    Content = contentProvided;
    UpdatedAt = DateTime.Now;
  }

  public void UpdateTitle(string newTitle)
  {
    Title = Guard.Against.NullOrEmpty(newTitle, nameof(newTitle));
    UpdatedAt = DateTime.Now;
  }
}
