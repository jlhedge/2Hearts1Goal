namespace _2Hearts1Goal.Modules.Accounts.Application.Services;

public interface ISessionTokenIssuer
{
    Guid Issue();
    DateTimeOffset GetExpiryUtc(DateTimeOffset issuedUtc);
}
