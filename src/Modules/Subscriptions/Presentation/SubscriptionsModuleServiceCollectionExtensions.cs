using _2Hearts1Goal.Modules.Subscriptions.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace _2Hearts1Goal.Modules.Subscriptions.Presentation;

public static class SubscriptionsModuleServiceCollectionExtensions
{
    public static IServiceCollection AddSubscriptionsPresentation(this IServiceCollection services)
    {
        services.AddSubscriptionsModule();
        return services;
    }
}
