using Ardalis.Result;
using Ardalis.SharedKernel;
using NotesApp.Domain.NoteAggregate;

namespace NotesApp.Application.Notes.Queries.GetById;

public class GetNoteByIdHandler : IQueryHandler<GetNoteByIdQuery, Result<NoteDTO>>
{
  private readonly IRepository<Note> _repository;

  public GetNoteByIdHandler(IRepository<Note> repository) => _repository = repository;

  public async Task<Result<NoteDTO>> Handle(GetNoteByIdQuery query, CancellationToken cancellationToken)
  {
    var note = await _repository.GetByIdAsync(query.NoteId, cancellationToken);

    if (note == null) return Result.NotFound();
    
    var noteDTO = new NoteDTO(note.Id, note.Title, note.Content, note.CreatedAt, note.UpdatedAt);
    return Result.Success(noteDTO);
  }
}
