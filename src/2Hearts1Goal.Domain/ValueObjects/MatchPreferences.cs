using _2Hearts1Goal.Domain.Enums;

namespace _2Hearts1Goal.Domain.ValueObjects;

public sealed class MatchPreferences
{
    public int MinimumAge { get; private set; } = 21;
    public int MaximumAge { get; private set; } = 45;
    public int MaximumDistanceMiles { get; private set; } = 50;
    public GenderIdentity InterestedIn { get; private set; } = GenderIdentity.Unspecified;
    public RelationshipIntent Intent { get; private set; } = RelationshipIntent.LongTerm;

    private MatchPreferences()
    {
    }

    public MatchPreferences(
        int minimumAge,
        int maximumAge,
        int maximumDistanceMiles,
        GenderIdentity interestedIn,
        RelationshipIntent intent)
    {
        if (minimumAge < 18)
        {
            throw new ArgumentOutOfRangeException(nameof(minimumAge), "Dating profiles must be 18+.");
        }

        if (maximumAge < minimumAge)
        {
            throw new ArgumentOutOfRangeException(nameof(maximumAge), "Maximum age must be >= minimum age.");
        }

        if (maximumDistanceMiles <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maximumDistanceMiles), "Distance must be positive.");
        }

        MinimumAge = minimumAge;
        MaximumAge = maximumAge;
        MaximumDistanceMiles = maximumDistanceMiles;
        InterestedIn = interestedIn;
        Intent = intent;
    }
}
