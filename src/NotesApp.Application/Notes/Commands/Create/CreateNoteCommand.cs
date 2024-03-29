using Ardalis.Result;

namespace NotesApp.Application.Notes.Commands.Create;

public record CreateNoteCommand(string Title, string? Content = null) 
  : Ardalis.SharedKernel.ICommand<Result<int>>;
