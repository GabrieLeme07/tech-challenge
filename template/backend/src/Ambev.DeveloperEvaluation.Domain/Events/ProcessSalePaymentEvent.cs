namespace Ambev.DeveloperEvaluation.Domain.Events;

public class ProcessSalePaymentEvent(string saleNumber) : BrokerMessage
{
    public string SaleNumber { get; } = saleNumber;

}
