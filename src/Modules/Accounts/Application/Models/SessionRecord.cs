namespace _2Hearts1Goal.Modules.Accounts.Application.Models;

public sealed class SessionRecord
{
    private SessionRecord()
    {
    }

    public SessionRecord(
        Guid accountId,
        Guid sessionToken,
        DateTimeOffset issuedUtc,
        DateTimeOffset expiresUtc)
    {
        AccountId = accountId;
        SessionToken = sessionToken;
        IssuedUtc = issuedUtc;
        ExpiresUtc = expiresUtc;
    }

    public Guid AccountId { get; private set; }
    public Guid SessionToken { get; private set; }
    public DateTimeOffset IssuedUtc { get; private set; }
    public DateTimeOffset ExpiresUtc { get; private set; }
}
