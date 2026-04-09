using _2Hearts1Goal.Modules.Search.Application.Contracts;

namespace _2Hearts1Goal.Modules.Search.Infrastructure;

public sealed class EmptyProfileSearchService : IProfileSearchService
{
    public Task<IReadOnlyCollection<ProfileSearchResult>> SearchAsync(ProfileSearchFilters filters, CancellationToken cancellationToken = default)
    {
        return Task.FromResult<IReadOnlyCollection<ProfileSearchResult>>([]);
    }
}
