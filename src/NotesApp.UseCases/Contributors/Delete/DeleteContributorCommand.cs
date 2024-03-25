using Ardalis.Result;
using Ardalis.SharedKernel;

namespace NotesApp.UseCases.Contributors.Delete;

public record DeleteContributorCommand(int ContributorId) : ICommand<Result>;
