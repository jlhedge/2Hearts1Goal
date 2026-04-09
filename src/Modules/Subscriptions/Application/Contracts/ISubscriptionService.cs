namespace _2Hearts1Goal.Modules.Subscriptions.Application.Contracts;

public interface ISubscriptionService
{
    Task<IReadOnlyCollection<SubscriptionPlan>> GetPlansAsync(CancellationToken cancellationToken = default);
    Task<SubscriptionSummary?> GetSubscriptionAsync(Guid accountId, CancellationToken cancellationToken = default);
}
