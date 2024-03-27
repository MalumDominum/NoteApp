using Ardalis.SharedKernel;
using FluentAssertions;
using NotesApp.Application.Notes.Commands.Create;
using NotesApp.Domain.NoteAggregate;
using NSubstitute;
using Xunit;

namespace NotesApp.UnitTests.Application.Notes;

public class CreateNoteHandlerHandle
{
  private const string TestTitle = "test title";
  private readonly IRepository<Note> _repository = Substitute.For<IRepository<Note>>();
  private readonly CreateNoteHandler _handler;

  public CreateNoteHandlerHandle() => _handler = new(_repository);

  private static Note CreateContributor() => new(TestTitle);

  [Fact]
  public async Task ReturnsSuccessGivenValidTitle()
  {
    _repository.AddAsync(Arg.Any<Note>(), Arg.Any<CancellationToken>())
      .Returns(Task.FromResult(CreateContributor()));
    var result = await _handler.Handle(new CreateNoteCommand(TestTitle, null), CancellationToken.None);

    result.IsSuccess.Should().BeTrue();
  }
}
