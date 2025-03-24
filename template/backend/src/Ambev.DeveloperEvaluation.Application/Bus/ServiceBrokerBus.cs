using Ambev.DeveloperEvaluation.Domain.Bus;
using Ambev.DeveloperEvaluation.Domain.Events;
using Microsoft.Extensions.Configuration;

namespace Ambev.DeveloperEvaluation.Application.Bus;

public sealed class ServiceBrokerBus : IMessageHandler
{
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Task Publish<TMessage>(TMessage message) where TMessage : BrokerMessage
    {
        return Task.CompletedTask;
    }
}
