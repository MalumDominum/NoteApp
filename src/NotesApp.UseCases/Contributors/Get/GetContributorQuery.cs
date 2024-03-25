using Ardalis.Result;
using Ardalis.SharedKernel;

namespace NotesApp.UseCases.Contributors.Get;

public record GetContributorQuery(int ContributorId) : IQuery<Result<ContributorDTO>>;
