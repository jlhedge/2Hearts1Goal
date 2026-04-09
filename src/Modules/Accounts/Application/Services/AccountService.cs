using _2Hearts1Goal.Modules.Accounts.Application.Contracts;
using _2Hearts1Goal.Modules.Accounts.Application.Models;

namespace _2Hearts1Goal.Modules.Accounts.Application.Services;

public sealed class AccountService : IAccountService
{
    private readonly IAccountCredentialStore _credentialStore;
    private readonly IPasswordPolicy _passwordPolicy;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ISessionTokenIssuer _sessionTokenIssuer;

    public AccountService(
        IAccountCredentialStore credentialStore,
        IPasswordPolicy passwordPolicy,
        IPasswordHasher passwordHasher,
        ISessionTokenIssuer sessionTokenIssuer)
    {
        _credentialStore = credentialStore;
        _passwordPolicy = passwordPolicy;
        _passwordHasher = passwordHasher;
        _sessionTokenIssuer = sessionTokenIssuer;
    }

    public async Task<AuthenticationResult> RegisterAsync(RegisterAccountRequest request, CancellationToken cancellationToken = default)
    {
        var normalizedEmail = NormalizeEmail(request.Email);
        _passwordPolicy.Validate(request.Password);

        var existing = await _credentialStore.FindByEmailAsync(normalizedEmail, cancellationToken);
        if (existing is not null)
        {
            throw new InvalidOperationException("An account already exists for that email address.");
        }

        var (hash, salt) = _passwordHasher.Hash(request.Password);
        var account = new AccountCredentialRecord(
            Guid.NewGuid(),
            normalizedEmail,
            hash,
            salt);

        await _credentialStore.SaveAccountAsync(account, cancellationToken);

        return await CreateSessionAsync(account, cancellationToken);
    }

    public async Task<AuthenticationResult?> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
    {
        var normalizedEmail = NormalizeEmail(request.Email);
        var account = await _credentialStore.FindByEmailAsync(normalizedEmail, cancellationToken);

        if (account is null || !_passwordHasher.Verify(request.Password, account.PasswordHash, account.PasswordSalt))
        {
            return null;
        }

        return await CreateSessionAsync(account, cancellationToken);
    }

    private async Task<AuthenticationResult> CreateSessionAsync(AccountCredentialRecord account, CancellationToken cancellationToken)
    {
        var issuedUtc = DateTimeOffset.UtcNow;
        var sessionToken = _sessionTokenIssuer.Issue();
        var expiresUtc = _sessionTokenIssuer.GetExpiryUtc(issuedUtc);

        await _credentialStore.SaveSessionAsync(
            new SessionRecord(account.AccountId, sessionToken, issuedUtc, expiresUtc),
            cancellationToken);

        return new AuthenticationResult(account.AccountId, account.Email, sessionToken, expiresUtc);
    }

    private static string NormalizeEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Email is required.", nameof(email));
        }

        return email.Trim().ToLowerInvariant();
    }
}
