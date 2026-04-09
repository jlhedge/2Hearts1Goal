using _2Hearts1Goal.Modules.Accounts.Application.Contracts;
using _2Hearts1Goal.Modules.Accounts.Application.Services;
using _2Hearts1Goal.Modules.Accounts.Infrastructure.Security;
using _2Hearts1Goal.Modules.Accounts.Infrastructure.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _2Hearts1Goal.Modules.Accounts.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddAccountsModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AccountSessionOptions>(configuration.GetSection(AccountSessionOptions.SectionName));
        services.AddScoped<IAccountCredentialStore, SqlAccountCredentialStore>();
        services.AddSingleton<IPasswordPolicy, PasswordPolicy>();
        services.AddSingleton<IPasswordHasher, Pbkdf2PasswordHasher>();
        services.AddSingleton<ISessionTokenIssuer, GuidSessionTokenIssuer>();
        services.AddScoped<IAccountService, AccountService>();

        return services;
    }
}
