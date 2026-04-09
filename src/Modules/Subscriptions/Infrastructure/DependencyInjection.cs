using _2Hearts1Goal.Modules.Subscriptions.Application.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace _2Hearts1Goal.Modules.Subscriptions.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddSubscriptionsModule(this IServiceCollection services)
    {
        services.AddSingleton<ISubscriptionService, SubscriptionCatalogService>();
        return services;
    }
}
