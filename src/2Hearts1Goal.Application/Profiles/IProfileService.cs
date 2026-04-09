namespace _2Hearts1Goal.Application.Profiles;

public interface IProfileService
{
    Task<IReadOnlyCollection<ProfileDto>> GetProfilesAsync(CancellationToken cancellationToken = default);
    Task<ProfileDto?> GetProfileByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<ProfileDto> CreateProfileAsync(CreateProfileRequest request, CancellationToken cancellationToken = default);
}
