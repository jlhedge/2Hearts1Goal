namespace _2Hearts1Goal.Modules.Accounts.Application.Services;

public interface IPasswordPolicy
{
    void Validate(string password);
}
