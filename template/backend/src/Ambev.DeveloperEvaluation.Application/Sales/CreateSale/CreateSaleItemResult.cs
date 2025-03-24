namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public record CreateSaleItemResult
{
    public int Id { get; init; }
    public int SaleId { get; init; }
    public int ProductId { get; init; }
    public int Quantity { get; init; }
    public decimal Discount { get; init; } = 0;
    public decimal TotalAmount { get; init; }
}
