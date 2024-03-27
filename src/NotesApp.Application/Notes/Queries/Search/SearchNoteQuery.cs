using Ardalis.Result;
using Ardalis.SharedKernel;

namespace NotesApp.Application.Notes.Queries.Search;

public record SearchNoteQuery(string? SearchValue) : IQuery<Result<IEnumerable<NoteDTO>>>;
