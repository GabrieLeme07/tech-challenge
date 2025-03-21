namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public record CreateSaleResult
{
    public Guid Id { get; init; }
    public DateTime SaleDate { get; init; }
    public Guid CustomerId { get; init; }
    public string Branch { get; init; } = string.Empty;
    public List<CreateSaleItemResult> Items { get; init; } = new List<CreateSaleItemResult>();
    public decimal TotalAmount { get; init; }
    public bool IsCancelled { get; init; }
}
