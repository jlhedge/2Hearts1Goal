namespace _2Hearts1Goal.Modules.Subscriptions.Application.Contracts;

public sealed record SubscriptionPlan(
    string Code,
    string DisplayName,
    decimal MonthlyPrice,
    bool IncludesUnlimitedLikes,
    bool IncludesReadReceipts,
    bool IncludesPriorityPlacement);
