namespace _2Hearts1Goal.Modules.Messaging.Application.Contracts;

public interface IWorkerMessagePublisher
{
    Task PublishAsync(WorkerMessage message, CancellationToken cancellationToken = default);
}
