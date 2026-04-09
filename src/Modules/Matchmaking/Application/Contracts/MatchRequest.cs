namespace _2Hearts1Goal.Modules.Matchmaking.Application.Contracts;

public sealed record MatchRequest(
    Guid ProfileId,
    int PageSize = 25);
