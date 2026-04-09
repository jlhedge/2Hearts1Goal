using _2Hearts1Goal.Modules.Users.Application.Models;

namespace _2Hearts1Goal.Modules.Users.Application.Services;

public interface IUserStore
{
    Task<UserRecord?> FindByAccountIdAsync(Guid accountId, CancellationToken cancellationToken = default);
    Task<UserRecord?> FindByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task SaveAsync(UserRecord user, CancellationToken cancellationToken = default);
}
