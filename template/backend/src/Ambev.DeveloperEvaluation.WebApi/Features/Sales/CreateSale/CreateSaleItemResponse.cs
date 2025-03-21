namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public record CreateSaleItemResponse
{
    public int Id { get; init; }
    public Guid SaleId { get; init; }
    public Guid ProductId { get; init; }
    public int Quantity { get; init; }
    public decimal Discount { get; init; }
    public decimal TotalAmount { get; init; }
}
