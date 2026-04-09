using _2Hearts1Goal.Infrastructure.Persistence;
using _2Hearts1Goal.Modules.Users.Application.Models;
using _2Hearts1Goal.Modules.Users.Application.Services;
using Microsoft.EntityFrameworkCore;

namespace _2Hearts1Goal.Modules.Users.Infrastructure.Storage;

public sealed class SqlUserStore : IUserStore
{
    private readonly ApplicationDbContext _dbContext;

    public SqlUserStore(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<UserRecord?> FindByAccountIdAsync(Guid accountId, CancellationToken cancellationToken = default)
    {
        return _dbContext.Users
            .SingleOrDefaultAsync(user => user.AccountId == accountId, cancellationToken);
    }

    public Task<UserRecord?> FindByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return _dbContext.Users
            .SingleOrDefaultAsync(user => user.UserId == userId, cancellationToken);
    }

    public async Task SaveAsync(UserRecord user, CancellationToken cancellationToken = default)
    {
        var existing = await _dbContext.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(current => current.UserId == user.UserId, cancellationToken);

        if (existing is null)
        {
            _dbContext.Users.Add(user);
        }
        else
        {
            _dbContext.Users.Update(user);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
