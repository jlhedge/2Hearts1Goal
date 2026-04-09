using _2Hearts1Goal.Modules.Accounts.Application.Services;
using Microsoft.Extensions.Options;

namespace _2Hearts1Goal.Modules.Accounts.Infrastructure.Security;

public sealed class GuidSessionTokenIssuer : ISessionTokenIssuer
{
    private readonly AccountSessionOptions _options;

    public GuidSessionTokenIssuer(IOptions<AccountSessionOptions> options)
    {
        _options = options.Value;
    }

    public Guid Issue()
    {
        return Guid.NewGuid();
    }

    public DateTimeOffset GetExpiryUtc(DateTimeOffset issuedUtc)
    {
        return issuedUtc.AddMinutes(_options.DurationMinutes);
    }
}
