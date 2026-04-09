using _2Hearts1Goal.Application.Profiles;
using Microsoft.AspNetCore.Mvc;

namespace _2Hearts1Goal.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ProfilesController : ControllerBase
{
    private readonly IProfileService _profileService;

    public ProfilesController(IProfileService profileService)
    {
        _profileService = profileService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyCollection<ProfileDto>>> GetProfiles(CancellationToken cancellationToken)
    {
        var profiles = await _profileService.GetProfilesAsync(cancellationToken);
        return Ok(profiles);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProfileDto>> GetProfileById(Guid id, CancellationToken cancellationToken)
    {
        var profile = await _profileService.GetProfileByIdAsync(id, cancellationToken);
        return profile is null ? NotFound() : Ok(profile);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<ProfileDto>> CreateProfile(
        [FromBody] CreateProfileRequest request,
        CancellationToken cancellationToken)
    {
        var profile = await _profileService.CreateProfileAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetProfileById), new { id = profile.Id }, profile);
    }
}
