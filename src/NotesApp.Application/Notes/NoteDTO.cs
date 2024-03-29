namespace NotesApp.Application.Notes;

public class NoteDTO
{
  public int Id { get; init; }
  public string Title { get; set; }
  public string Content { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }

  public NoteDTO(int id, string title, string content, DateTime createdAt, DateTime? updatedAt)
  {
    Id = id;
    Title = title;
    Content = content;
    CreatedAt = createdAt;
    UpdatedAt = updatedAt;
  }
}
