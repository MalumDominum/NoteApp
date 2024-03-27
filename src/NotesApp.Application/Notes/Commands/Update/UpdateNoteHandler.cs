using Ardalis.Result;
using Ardalis.SharedKernel;
using NotesApp.Domain.NoteAggregate;

namespace NotesApp.Application.Notes.Commands.Update;

public class UpdateNoteHandler : ICommandHandler<UpdateNoteCommand, Result<NoteDTO>>
{
  private readonly IRepository<Note> _repository;

  public UpdateNoteHandler(IRepository<Note> repository) => _repository = repository;

  public async Task<Result<NoteDTO>> Handle(UpdateNoteCommand command, CancellationToken cancellationToken)
  {
    var existingNote = await _repository.GetByIdAsync(command.NoteId, cancellationToken);
    if (existingNote == null)
      return Result.NotFound();

    existingNote.UpdateTitle(command.NewTitle);
    existingNote.UpdateContent(command.NewContent);

    await _repository.UpdateAsync(existingNote, cancellationToken);

    return Result.Success(new NoteDTO(existingNote.Id, existingNote.Title,
      existingNote.Content, existingNote.CreatedAt, existingNote.UpdatedAt));
  }
}
