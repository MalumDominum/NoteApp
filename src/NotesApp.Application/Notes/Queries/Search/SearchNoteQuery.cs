using Ardalis.Result;
using Ardalis.SharedKernel;

namespace NotesApp.Application.Notes.Queries.Search;

public record SearchNoteQuery(string? SearchValue = null) : IQuery<Result<IEnumerable<NoteDTO>>>;
