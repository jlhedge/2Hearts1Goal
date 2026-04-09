namespace _2Hearts1Goal.Modules.Accounts.Infrastructure.Security;

public sealed class AccountSessionOptions
{
    public const string SectionName = "Accounts:Sessions";
    public int DurationMinutes { get; set; } = 120;
}
