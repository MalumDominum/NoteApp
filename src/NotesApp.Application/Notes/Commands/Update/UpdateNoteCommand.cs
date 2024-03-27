using Ardalis.Result;
using Ardalis.SharedKernel;

namespace NotesApp.Application.Notes.Commands.Update;

public record UpdateNoteCommand(
  int NoteId,
  string NewTitle,
  string NewContent) : ICommand<Result<NoteDTO>>;
