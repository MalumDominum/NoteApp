namespace NotesApp.Application.Notes;

public record NoteDTO(
  int NoteId,
  string Title,
  string Content,
  DateTime CreatedAt,
  DateTime? UpdatedAt);
