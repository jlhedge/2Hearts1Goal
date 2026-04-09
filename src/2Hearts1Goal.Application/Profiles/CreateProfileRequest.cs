using _2Hearts1Goal.Domain.Enums;

namespace _2Hearts1Goal.Application.Profiles;

public sealed record CreateProfileRequest(
    string DisplayName,
    DateOnly BirthDate,
    GenderIdentity GenderIdentity,
    string City,
    string StateOrProvince,
    RelationshipIntent RelationshipIntent,
    string Bio,
    int PreferredMinimumAge,
    int PreferredMaximumAge,
    int PreferredMaximumDistanceMiles,
    GenderIdentity InterestedIn,
    RelationshipIntent PreferredIntent);
