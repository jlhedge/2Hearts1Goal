using _2Hearts1Goal.Domain.Common;
using _2Hearts1Goal.Domain.Enums;
using _2Hearts1Goal.Domain.ValueObjects;

namespace _2Hearts1Goal.Domain.Entities;

public sealed class Profile : Entity
{
    private Profile()
    {
    }

    public Profile(
        string displayName,
        DateOnly birthDate,
        GenderIdentity genderIdentity,
        string city,
        string stateOrProvince,
        RelationshipIntent relationshipIntent,
        MatchPreferences matchPreferences,
        string bio)
    {
        SetCoreDetails(displayName, birthDate, genderIdentity, city, stateOrProvince, relationshipIntent, bio);
        MatchPreferences = matchPreferences;
    }

    public string DisplayName { get; private set; } = string.Empty;
    public DateOnly BirthDate { get; private set; }
    public GenderIdentity GenderIdentity { get; private set; }
    public string City { get; private set; } = string.Empty;
    public string StateOrProvince { get; private set; } = string.Empty;
    public RelationshipIntent RelationshipIntent { get; private set; }
    public string Bio { get; private set; } = string.Empty;
    public MatchPreferences MatchPreferences { get; private set; } =
        new(21, 45, 50, GenderIdentity.Unspecified, RelationshipIntent.LongTerm);

    public void Update(
        string displayName,
        DateOnly birthDate,
        GenderIdentity genderIdentity,
        string city,
        string stateOrProvince,
        RelationshipIntent relationshipIntent,
        MatchPreferences matchPreferences,
        string bio)
    {
        SetCoreDetails(displayName, birthDate, genderIdentity, city, stateOrProvince, relationshipIntent, bio);
        MatchPreferences = matchPreferences;
        Touch();
    }

    private void SetCoreDetails(
        string displayName,
        DateOnly birthDate,
        GenderIdentity genderIdentity,
        string city,
        string stateOrProvince,
        RelationshipIntent relationshipIntent,
        string bio)
    {
        if (string.IsNullOrWhiteSpace(displayName))
        {
            throw new ArgumentException("Display name is required.", nameof(displayName));
        }

        if (birthDate > DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-18)))
        {
            throw new ArgumentOutOfRangeException(nameof(birthDate), "Users must be at least 18 years old.");
        }

        DisplayName = displayName.Trim();
        BirthDate = birthDate;
        GenderIdentity = genderIdentity;
        City = city.Trim();
        StateOrProvince = stateOrProvince.Trim();
        RelationshipIntent = relationshipIntent;
        Bio = bio.Trim();
    }
}
