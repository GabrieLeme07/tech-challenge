namespace Ambev.DeveloperEvaluation.Domain.Events;

public class SaleNotificationEvent(string saleNumber, int customerId) : BrokerMessage
{
    public string SaleNumber { get; } = saleNumber;
    public int CustomerId { get; } = customerId;
}
