using _2Hearts1Goal.Modules.Search.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace _2Hearts1Goal.Modules.Search.Presentation;

public static class SearchModuleServiceCollectionExtensions
{
    public static IServiceCollection AddSearchPresentation(this IServiceCollection services)
    {
        services.AddSearchModule();
        return services;
    }
}
