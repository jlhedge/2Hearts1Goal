using _2Hearts1Goal.Modules.Messaging.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace _2Hearts1Goal.Modules.Messaging.Presentation;

public static class MessagingModuleServiceCollectionExtensions
{
    public static IServiceCollection AddMessagingPresentation(this IServiceCollection services)
    {
        services.AddMessagingModule();
        return services;
    }
}
