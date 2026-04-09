namespace _2Hearts1Goal.Modules.Matchmaking.Application.Contracts;

public sealed record MatchCandidate(
    Guid ProfileId,
    decimal Score,
    string[] Reasons);
