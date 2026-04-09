namespace _2Hearts1Goal.Modules.Users.Application.Models;

public sealed class UserRecord
{
    private UserRecord()
    {
    }

    public UserRecord(
        Guid userId,
        Guid accountId,
        string displayName,
        DateOnly birthDate,
        string timeZone,
        bool marketingOptIn,
        bool discoverable,
        bool pushNotificationsEnabled)
    {
        UserId = userId;
        AccountId = accountId;
        DisplayName = displayName;
        BirthDate = birthDate;
        TimeZone = timeZone;
        MarketingOptIn = marketingOptIn;
        Discoverable = discoverable;
        PushNotificationsEnabled = pushNotificationsEnabled;
    }

    public Guid UserId { get; private set; }
    public Guid AccountId { get; private set; }
    public string DisplayName { get; private set; } = string.Empty;
    public DateOnly BirthDate { get; private set; }
    public string TimeZone { get; private set; } = string.Empty;
    public bool MarketingOptIn { get; private set; }
    public bool Discoverable { get; private set; }
    public bool PushNotificationsEnabled { get; private set; }

    public UserRecord UpdateSettings(
        string timeZone,
        bool marketingOptIn,
        bool discoverable,
        bool pushNotificationsEnabled)
    {
        TimeZone = timeZone;
        MarketingOptIn = marketingOptIn;
        Discoverable = discoverable;
        PushNotificationsEnabled = pushNotificationsEnabled;
        return this;
    }
}
