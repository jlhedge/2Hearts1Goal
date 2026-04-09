using _2Hearts1Goal.Modules.Users.Application.Contracts;
using _2Hearts1Goal.Modules.Users.Application.Services;
using _2Hearts1Goal.Modules.Users.Infrastructure.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace _2Hearts1Goal.Modules.Users.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddUsersModule(this IServiceCollection services)
    {
        services.AddScoped<IUserStore, SqlUserStore>();
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}
