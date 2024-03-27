using Ardalis.Result;
using Ardalis.SharedKernel;
using NotesApp.Domain.NoteAggregate;
using NotesApp.Domain.NoteAggregate.Specifications;

namespace NotesApp.Application.Notes.Queries.Search;

public class SearchNoteHandler : IQueryHandler<SearchNoteQuery, Result<IEnumerable<NoteDTO>>>
{
  private readonly IRepository<Note> _repository;

  public SearchNoteHandler(IRepository<Note> repository) => _repository = repository;

  public async Task<Result<IEnumerable<NoteDTO>>> Handle(SearchNoteQuery query, CancellationToken cancellationToken)
  {
    var notes = query.SearchValue == null
      ? await _repository.ListAsync(cancellationToken)
      : await _repository.ListAsync(new NoteSearchSpec(query.SearchValue), cancellationToken);

    var noteDTOs = notes.Select(note => new NoteDTO(note.Id, note.Title, note.Content, note.CreatedAt, note.UpdatedAt));

    return Result.Success(noteDTOs);
  }
}
