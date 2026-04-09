namespace _2Hearts1Goal.Modules.Accounts.Application.Contracts;

public interface IAccountService
{
    Task<AuthenticationResult> RegisterAsync(RegisterAccountRequest request, CancellationToken cancellationToken = default);
    Task<AuthenticationResult?> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);
}
