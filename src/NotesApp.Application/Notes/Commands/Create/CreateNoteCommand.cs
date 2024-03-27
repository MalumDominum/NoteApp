using Ardalis.Result;

namespace NotesApp.Application.Notes.Commands.Create;

public record CreateNoteCommand(
    string Title,
    string? Content) : Ardalis.SharedKernel.ICommand<Result<int>>;
