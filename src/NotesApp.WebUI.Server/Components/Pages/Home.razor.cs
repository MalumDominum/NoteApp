using NotesApp.Application.Notes.Commands.Delete;
using NotesApp.Application.Notes.Commands.Update;
using NotesApp.Application.Notes.Queries.GetById;
using NotesApp.Application.Notes.Queries.Search;
using NotesApp.Application.Notes.Commands.Create;
using NotesApp.Application.Notes;
using MediatR;
using Microsoft.AspNetCore.Components;
using NotesApp.Application.Notes.Queries.Count;

namespace NotesApp.WebUI.Server.Components.Pages;

public partial class Home
{
  protected List<NoteDTO>? Notes;
  protected int TotalNotesCount;
  protected string? SearchValue;

  [Inject]
  protected NavigationManager NavigationManager { get; set; } = null!;
  [Inject]
  protected IMediator Mediator { get; set; } = null!;

  private async Task LoadNotes(string? searchValue = null)
  {
    var result = await Mediator.Send(new SearchNoteQuery(searchValue ?? SearchValue));

    if (result.IsSuccess) Notes = result.Value.ToList();
  }

  private async Task<int> CountNotes() => (await Mediator.Send(new CountNoteQuery())).Value;

  private async Task CreateNote()
  {
    NavigationManager.NavigateTo("/");
    var result = await Mediator.Send(new CreateNoteCommand("New Note"));

    if (result.IsSuccess)
      await OnInitializedAsync();
  }

  private async Task RefreshNote(NoteDTO note)
  {
    var result = await Mediator.Send(new GetNoteByIdQuery(note.Id));

    if (result.IsSuccess)
    {
      note.Title = result.Value.Title;
      note.Content = result.Value.Content;
      note.CreatedAt = result.Value.CreatedAt;
      note.UpdatedAt = result.Value.UpdatedAt;
    }
  }

  private async Task UpdateNote(NoteDTO note)
  {
    var result = await Mediator.Send(new UpdateNoteCommand(note.Id, note.Title, note.Content));

    if (result.IsSuccess) await OnInitializedAsync();
  }

  private async Task DeleteNote(int noteId)
  {
    var result = await Mediator.Send(new DeleteNoteCommand(noteId));

    if (result.IsSuccess) await OnInitializedAsync();
  }
}
