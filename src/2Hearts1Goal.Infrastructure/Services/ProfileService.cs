using _2Hearts1Goal.Application.Common.Interfaces;
using _2Hearts1Goal.Application.Profiles;
using _2Hearts1Goal.Domain.Entities;
using _2Hearts1Goal.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace _2Hearts1Goal.Infrastructure.Services;

public sealed class ProfileService : IProfileService
{
    private readonly IApplicationDbContext _dbContext;

    public ProfileService(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<ProfileDto>> GetProfilesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Profiles
            .AsNoTracking()
            .OrderBy(profile => profile.DisplayName)
            .Select(profile => new ProfileDto(
                profile.Id,
                profile.DisplayName,
                profile.BirthDate,
                profile.GenderIdentity,
                profile.City,
                profile.StateOrProvince,
                profile.RelationshipIntent,
                profile.Bio,
                profile.MatchPreferences.MinimumAge,
                profile.MatchPreferences.MaximumAge,
                profile.MatchPreferences.MaximumDistanceMiles,
                profile.MatchPreferences.InterestedIn,
                profile.MatchPreferences.Intent))
            .ToListAsync(cancellationToken);
    }

    public async Task<ProfileDto?> GetProfileByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Profiles
            .AsNoTracking()
            .Where(profile => profile.Id == id)
            .Select(profile => new ProfileDto(
                profile.Id,
                profile.DisplayName,
                profile.BirthDate,
                profile.GenderIdentity,
                profile.City,
                profile.StateOrProvince,
                profile.RelationshipIntent,
                profile.Bio,
                profile.MatchPreferences.MinimumAge,
                profile.MatchPreferences.MaximumAge,
                profile.MatchPreferences.MaximumDistanceMiles,
                profile.MatchPreferences.InterestedIn,
                profile.MatchPreferences.Intent))
            .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<ProfileDto> CreateProfileAsync(CreateProfileRequest request, CancellationToken cancellationToken = default)
    {
        var profile = new Profile(
            request.DisplayName,
            request.BirthDate,
            request.GenderIdentity,
            request.City,
            request.StateOrProvince,
            request.RelationshipIntent,
            new MatchPreferences(
                request.PreferredMinimumAge,
                request.PreferredMaximumAge,
                request.PreferredMaximumDistanceMiles,
                request.InterestedIn,
                request.PreferredIntent),
            request.Bio);

        _dbContext.Profiles.Add(profile);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new ProfileDto(
            profile.Id,
            profile.DisplayName,
            profile.BirthDate,
            profile.GenderIdentity,
            profile.City,
            profile.StateOrProvince,
            profile.RelationshipIntent,
            profile.Bio,
            profile.MatchPreferences.MinimumAge,
            profile.MatchPreferences.MaximumAge,
            profile.MatchPreferences.MaximumDistanceMiles,
            profile.MatchPreferences.InterestedIn,
            profile.MatchPreferences.Intent);
    }
}
