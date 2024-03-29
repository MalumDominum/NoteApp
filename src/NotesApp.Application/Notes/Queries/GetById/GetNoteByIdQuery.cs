using Ardalis.Result;
using Ardalis.SharedKernel;

namespace NotesApp.Application.Notes.Queries.ById;

public record GetNoteByIdQuery(int NoteId) : IQuery<Result<NoteDTO>>;
