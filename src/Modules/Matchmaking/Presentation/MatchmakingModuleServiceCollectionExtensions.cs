using _2Hearts1Goal.Modules.Matchmaking.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace _2Hearts1Goal.Modules.Matchmaking.Presentation;

public static class MatchmakingModuleServiceCollectionExtensions
{
    public static IServiceCollection AddMatchmakingPresentation(this IServiceCollection services)
    {
        services.AddMatchmakingModule();
        return services;
    }
}
