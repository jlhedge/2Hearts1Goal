using _2Hearts1Goal.Modules.Accounts.Application.Models;

namespace _2Hearts1Goal.Modules.Accounts.Application.Services;

public interface IAccountCredentialStore
{
    Task<AccountCredentialRecord?> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken = default);
    Task SaveAccountAsync(AccountCredentialRecord account, CancellationToken cancellationToken = default);
    Task SaveSessionAsync(SessionRecord session, CancellationToken cancellationToken = default);
}
