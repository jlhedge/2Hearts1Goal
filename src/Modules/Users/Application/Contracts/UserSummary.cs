namespace _2Hearts1Goal.Modules.Users.Application.Contracts;

public sealed record UserSummary(
    Guid UserId,
    Guid AccountId,
    string DisplayName,
    DateOnly BirthDate,
    string TimeZone,
    bool MarketingOptIn,
    bool Discoverable,
    bool PushNotificationsEnabled);
