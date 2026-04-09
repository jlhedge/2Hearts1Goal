using _2Hearts1Goal.Modules.Matchmaking.Application.Contracts;

namespace _2Hearts1Goal.Modules.Matchmaking.Infrastructure;

public sealed class EmptyMatchmakingService : IMatchmakingService
{
    public Task<IReadOnlyCollection<MatchCandidate>> FindMatchesAsync(MatchRequest request, CancellationToken cancellationToken = default)
    {
        return Task.FromResult<IReadOnlyCollection<MatchCandidate>>([]);
    }
}
