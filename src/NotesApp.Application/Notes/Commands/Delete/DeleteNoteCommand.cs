using Ardalis.Result;
using Ardalis.SharedKernel;

namespace NotesApp.Application.Notes.Commands.Delete;

public record DeleteNoteCommand(int NoteId) : ICommand<Result>;
