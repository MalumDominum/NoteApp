using Ardalis.Result;
using Ardalis.SharedKernel;

namespace NotesApp.Application.Notes.Queries.Count;

public record CountNoteQuery : IQuery<Result<int>>;
