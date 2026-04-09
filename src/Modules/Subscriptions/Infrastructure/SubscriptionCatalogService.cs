using _2Hearts1Goal.Modules.Subscriptions.Application.Contracts;

namespace _2Hearts1Goal.Modules.Subscriptions.Infrastructure;

public sealed class SubscriptionCatalogService : ISubscriptionService
{
    private static readonly IReadOnlyCollection<SubscriptionPlan> Plans =
    [
        new("free", "Free", 0m, false, false, false),
        new("plus", "Plus", 14.99m, true, false, false),
        new("premium", "Premium", 24.99m, true, true, true)
    ];

    public Task<IReadOnlyCollection<SubscriptionPlan>> GetPlansAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(Plans);
    }

    public Task<SubscriptionSummary?> GetSubscriptionAsync(Guid accountId, CancellationToken cancellationToken = default)
    {
        return Task.FromResult<SubscriptionSummary?>(null);
    }
}
