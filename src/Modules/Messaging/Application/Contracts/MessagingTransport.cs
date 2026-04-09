namespace _2Hearts1Goal.Modules.Messaging.Application.Contracts;

public enum MessagingTransport
{
    SqlOutbox = 0,
    SqlBroker = 1,
    RabbitMq = 2
}
