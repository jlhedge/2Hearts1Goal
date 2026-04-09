namespace _2Hearts1Goal.Modules.Search.Application.Contracts;

public interface IProfileSearchService
{
    Task<IReadOnlyCollection<ProfileSearchResult>> SearchAsync(ProfileSearchFilters filters, CancellationToken cancellationToken = default);
}
