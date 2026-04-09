namespace _2Hearts1Goal.Modules.Search.Application.Contracts;

public sealed record ProfileSearchResult(
    Guid ProfileId,
    string DisplayName,
    string City,
    string StateOrProvince,
    string BioSnippet);
