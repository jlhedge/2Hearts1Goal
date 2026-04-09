using _2Hearts1Goal.Modules.Accounts.Application.Services;

namespace _2Hearts1Goal.Modules.Accounts.Infrastructure.Security;

public sealed class PasswordPolicy : IPasswordPolicy
{
    public void Validate(string password)
    {
        if (string.IsNullOrWhiteSpace(password) || password.Length < 10)
        {
            throw new ArgumentException("Password must be at least 10 characters.");
        }

        if (!password.Any(char.IsUpper) || !password.Any(char.IsLower) || !password.Any(char.IsDigit))
        {
            throw new ArgumentException("Password must include upper, lower, and numeric characters.");
        }
    }
}
