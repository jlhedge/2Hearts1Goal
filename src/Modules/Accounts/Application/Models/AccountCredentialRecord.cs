namespace _2Hearts1Goal.Modules.Accounts.Application.Models;

public sealed class AccountCredentialRecord
{
    private AccountCredentialRecord()
    {
    }

    public AccountCredentialRecord(
        Guid accountId,
        string email,
        string passwordHash,
        string passwordSalt)
    {
        AccountId = accountId;
        Email = email;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }

    public Guid AccountId { get; private set; }
    public string Email { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public string PasswordSalt { get; private set; } = string.Empty;
}
