using _2Hearts1Goal.Modules.Users.Application.Contracts;
using _2Hearts1Goal.Modules.Users.Application.Models;

namespace _2Hearts1Goal.Modules.Users.Application.Services;

public sealed class UserService : IUserService
{
    private readonly IUserStore _userStore;

    public UserService(IUserStore userStore)
    {
        _userStore = userStore;
    }

    public async Task<UserSummary> CreateAsync(CreateUserRequest request, CancellationToken cancellationToken = default)
    {
        var existing = await _userStore.FindByAccountIdAsync(request.AccountId, cancellationToken);
        if (existing is not null)
        {
            throw new InvalidOperationException("A user record already exists for that account.");
        }

        var user = new UserRecord(
            Guid.NewGuid(),
            request.AccountId,
            request.DisplayName.Trim(),
            request.BirthDate,
            string.IsNullOrWhiteSpace(request.TimeZone) ? "America/New_York" : request.TimeZone.Trim(),
            request.MarketingOptIn,
            true,
            true);

        await _userStore.SaveAsync(user, cancellationToken);

        return ToSummary(user);
    }

    public async Task<UserSummary?> GetByAccountIdAsync(Guid accountId, CancellationToken cancellationToken = default)
    {
        var user = await _userStore.FindByAccountIdAsync(accountId, cancellationToken);
        return user is null ? null : ToSummary(user);
    }

    public async Task<UserSummary?> UpdateSettingsAsync(UpdateUserSettingsRequest request, CancellationToken cancellationToken = default)
    {
        var existing = await _userStore.FindByUserIdAsync(request.UserId, cancellationToken);
        if (existing is null)
        {
            return null;
        }

        var updated = existing.UpdateSettings(
            string.IsNullOrWhiteSpace(request.TimeZone) ? existing.TimeZone : request.TimeZone.Trim(),
            request.MarketingOptIn,
            request.Discoverable,
            request.PushNotificationsEnabled);

        await _userStore.SaveAsync(updated, cancellationToken);
        return ToSummary(updated);
    }

    private static UserSummary ToSummary(UserRecord user)
    {
        return new UserSummary(
            user.UserId,
            user.AccountId,
            user.DisplayName,
            user.BirthDate,
            user.TimeZone,
            user.MarketingOptIn,
            user.Discoverable,
            user.PushNotificationsEnabled);
    }
}
