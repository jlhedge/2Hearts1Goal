using _2Hearts1Goal.Modules.Messaging.Application.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace _2Hearts1Goal.Modules.Messaging.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddMessagingModule(this IServiceCollection services)
    {
        services.AddSingleton<IWorkerMessagePublisher, NoOpWorkerMessagePublisher>();
        return services;
    }
}
