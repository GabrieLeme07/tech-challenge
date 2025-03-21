namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public record CreateSaleItemRequest
{
    public int Id { get; init; }
    public Guid ProductId { get; init; }

    public int Quantity { get; init; }
}
