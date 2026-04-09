namespace _2Hearts1Goal.Modules.Accounts.Application.Contracts;

public sealed record RegisterAccountRequest(
    string Email,
    string Password);
