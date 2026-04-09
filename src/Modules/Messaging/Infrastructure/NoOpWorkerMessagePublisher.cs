using _2Hearts1Goal.Modules.Messaging.Application.Contracts;

namespace _2Hearts1Goal.Modules.Messaging.Infrastructure;

public sealed class NoOpWorkerMessagePublisher : IWorkerMessagePublisher
{
    public Task PublishAsync(WorkerMessage message, CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }
}
