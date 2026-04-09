namespace _2Hearts1Goal.Modules.Users.Application.Contracts;

public sealed record CreateUserRequest(
    Guid AccountId,
    string DisplayName,
    DateOnly BirthDate,
    string TimeZone,
    bool MarketingOptIn);
