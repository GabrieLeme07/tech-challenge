namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleRequest
{
    public Guid CustomerId { get; init; }
    public Guid CartId { get; init; }

    public string Branch { get; init; }
}
