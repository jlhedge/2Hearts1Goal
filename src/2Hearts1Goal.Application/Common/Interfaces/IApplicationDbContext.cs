using _2Hearts1Goal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace _2Hearts1Goal.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Profile> Profiles { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
