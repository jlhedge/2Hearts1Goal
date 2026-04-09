namespace _2Hearts1Goal.Modules.Users.Application.Contracts;

public interface IUserService
{
    Task<UserSummary> CreateAsync(CreateUserRequest request, CancellationToken cancellationToken = default);
    Task<UserSummary?> GetByAccountIdAsync(Guid accountId, CancellationToken cancellationToken = default);
    Task<UserSummary?> UpdateSettingsAsync(UpdateUserSettingsRequest request, CancellationToken cancellationToken = default);
}
