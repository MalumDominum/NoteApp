using Ardalis.Result;
using Ardalis.SharedKernel;
using NotesApp.Domain.NoteAggregate;

namespace NotesApp.Application.Notes.Queries.Count;

public class CountNoteHandler : IQueryHandler<CountNoteQuery, Result<int>>
{
  private readonly IRepository<Note> _repository;

  public CountNoteHandler(IRepository<Note> repository) => _repository = repository;

  public async Task<Result<int>> Handle(CountNoteQuery _, CancellationToken cancellationToken)
  {
    var notesCount = await _repository.CountAsync(cancellationToken);

    return Result.Success(notesCount);
  }
}
