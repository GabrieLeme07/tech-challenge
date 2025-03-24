using Ambev.DeveloperEvaluation.Domain.Events;

namespace Ambev.DeveloperEvaluation.Domain.Bus;

public interface IMessageHandler : IDisposable
{
    Task Publish<TMessage>(TMessage message)
        where TMessage : BrokerMessage;
}
