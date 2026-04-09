namespace _2Hearts1Goal.Modules.Users.Application.Contracts;

public sealed record UpdateUserSettingsRequest(
    Guid UserId,
    string TimeZone,
    bool MarketingOptIn,
    bool Discoverable,
    bool PushNotificationsEnabled);
