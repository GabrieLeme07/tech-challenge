namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public record CreateSaleResult
{
    public int Id { get; init; }
    public DateTime SaleDate { get; init; }
    public int CustomerId { get; init; }
    public string Branch { get; init; }
    public List<CreateSaleItemResult> Items { get; init; }
    public decimal TotalAmount { get; init; }
    public bool IsCancelled { get; init; }
}
