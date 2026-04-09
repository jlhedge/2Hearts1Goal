namespace _2Hearts1Goal.Modules.Matchmaking.Application.Contracts;

public interface IMatchmakingService
{
    Task<IReadOnlyCollection<MatchCandidate>> FindMatchesAsync(MatchRequest request, CancellationToken cancellationToken = default);
}
