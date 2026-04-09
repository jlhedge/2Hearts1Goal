using _2Hearts1Goal.Modules.Matchmaking.Application.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace _2Hearts1Goal.Modules.Matchmaking.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddMatchmakingModule(this IServiceCollection services)
    {
        services.AddSingleton<IMatchmakingService, EmptyMatchmakingService>();
        return services;
    }
}
