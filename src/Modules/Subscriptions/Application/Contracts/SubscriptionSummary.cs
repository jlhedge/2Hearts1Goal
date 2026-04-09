namespace _2Hearts1Goal.Modules.Subscriptions.Application.Contracts;

public sealed record SubscriptionSummary(
    Guid AccountId,
    string PlanCode,
    SubscriptionStatus Status,
    DateTimeOffset StartedUtc,
    DateTimeOffset? RenewsUtc);
