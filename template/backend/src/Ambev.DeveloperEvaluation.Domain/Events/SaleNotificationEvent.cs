namespace Ambev.DeveloperEvaluation.Domain.Events;

public class SaleNotificationEvent(string saleNumber, Guid customerId) : BrokerMessage
{
    public string SaleNumber { get; } = saleNumber;
    public Guid CustomerId { get; } = customerId;
}
