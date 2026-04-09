namespace _2Hearts1Goal.Modules.Accounts.Application.Contracts;

public sealed record AuthenticationResult(
    Guid AccountId,
    string Email,
    Guid SessionToken,
    DateTimeOffset ExpiresUtc);
