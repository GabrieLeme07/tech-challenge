namespace Ambev.DeveloperEvaluation.Domain.Events;

/// <summary>
/// Broker Message base class
/// </summary>
public abstract class BrokerMessage
{
    /// <summary>
    /// Message queue
    /// </summary>
    public string QueueName { get; }
}
