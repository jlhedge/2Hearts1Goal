using _2Hearts1Goal.Infrastructure.Persistence;
using _2Hearts1Goal.Modules.Accounts.Application.Models;
using _2Hearts1Goal.Modules.Accounts.Application.Services;
using Microsoft.EntityFrameworkCore;

namespace _2Hearts1Goal.Modules.Accounts.Infrastructure.Storage;

public sealed class SqlAccountCredentialStore : IAccountCredentialStore
{
    private readonly ApplicationDbContext _dbContext;

    public SqlAccountCredentialStore(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<AccountCredentialRecord?> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken = default)
    {
        return _dbContext.Accounts
            .SingleOrDefaultAsync(account => account.Email == normalizedEmail, cancellationToken);
    }

    public async Task SaveAccountAsync(AccountCredentialRecord account, CancellationToken cancellationToken = default)
    {
        var exists = await _dbContext.Accounts
            .AnyAsync(existing => existing.Email == account.Email, cancellationToken);

        if (exists)
        {
            throw new InvalidOperationException("An account already exists for that email address.");
        }

        _dbContext.Accounts.Add(account);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task SaveSessionAsync(SessionRecord session, CancellationToken cancellationToken = default)
    {
        _dbContext.Sessions.Add(session);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
