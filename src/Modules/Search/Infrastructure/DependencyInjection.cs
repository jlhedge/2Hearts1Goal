using _2Hearts1Goal.Modules.Search.Application.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace _2Hearts1Goal.Modules.Search.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddSearchModule(this IServiceCollection services)
    {
        services.AddSingleton<IProfileSearchService, EmptyProfileSearchService>();
        return services;
    }
}
