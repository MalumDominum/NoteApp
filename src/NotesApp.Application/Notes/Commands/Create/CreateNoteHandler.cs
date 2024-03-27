using Ardalis.Result;
using Ardalis.SharedKernel;
using NotesApp.Domain.NoteAggregate;

namespace NotesApp.Application.Notes.Commands.Create;

public class CreateNoteHandler : ICommandHandler<CreateNoteCommand, Result<int>>
{
  private readonly IRepository<Note> _repository;
  
  public CreateNoteHandler(IRepository<Note> repository) => _repository = repository;

  public async Task<Result<int>> Handle(CreateNoteCommand command, CancellationToken cancellationToken)
  {
    var newNote = new Note(command.Title, command.Content);
    var createdItem = await _repository.AddAsync(newNote, cancellationToken);

    return createdItem.Id;
  }
}
