using _2Hearts1Goal.Domain.Enums;

namespace _2Hearts1Goal.Modules.Search.Application.Contracts;

public sealed record ProfileSearchFilters(
    string? Query,
    string? City,
    string? StateOrProvince,
    int? MinimumAge,
    int? MaximumAge,
    GenderIdentity? GenderIdentity,
    RelationshipIntent? RelationshipIntent);
