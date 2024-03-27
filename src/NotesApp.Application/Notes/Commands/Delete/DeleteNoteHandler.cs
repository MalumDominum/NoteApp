using Ardalis.GuardClauses;
using Ardalis.Result;
using Ardalis.SharedKernel;
using NotesApp.Domain.NoteAggregate;

namespace NotesApp.Application.Notes.Commands.Delete;

public class DeleteNoteHandler : ICommandHandler<DeleteNoteCommand, Result>
{
  private readonly IRepository<Note> _repository;

  public DeleteNoteHandler(IRepository<Note> repository) => _repository = repository;

  public async Task<Result> Handle(DeleteNoteCommand command, CancellationToken cancellationToken)
  {
    var note = await _repository.GetByIdAsync(command.NoteId, cancellationToken);
    Guard.Against.Null(note, "Note with provided ID didn't exists.");
    
    await _repository.DeleteAsync(note, cancellationToken);
    
    return Result.Success();
  }
}
