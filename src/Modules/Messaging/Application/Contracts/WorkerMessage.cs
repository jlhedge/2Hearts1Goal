namespace _2Hearts1Goal.Modules.Messaging.Application.Contracts;

public sealed record WorkerMessage(
    Guid MessageId,
    string Topic,
    string Payload,
    MessagingTransport Transport,
    DateTimeOffset QueuedUtc);
