using _2Hearts1Goal.Application.Common.Interfaces;
using _2Hearts1Goal.Domain.Entities;
using _2Hearts1Goal.Modules.Accounts.Application.Models;
using _2Hearts1Goal.Modules.Users.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace _2Hearts1Goal.Infrastructure.Persistence;

public sealed class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Profile> Profiles => Set<Profile>();
    public DbSet<AccountCredentialRecord> Accounts => Set<AccountCredentialRecord>();
    public DbSet<SessionRecord> Sessions => Set<SessionRecord>();
    public DbSet<UserRecord> Users => Set<UserRecord>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
