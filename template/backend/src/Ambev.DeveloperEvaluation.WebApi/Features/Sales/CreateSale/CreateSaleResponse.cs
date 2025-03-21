namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleResponse
{
    public Guid Id { get; init; }
    public DateTime SaleDate { get; init; }
    public Guid CustomerId { get; init; }
    public string Branch { get; init; } = string.Empty;
    public List<CreateSaleItemResponse> Items { get; init; } = new List<CreateSaleItemResponse>();
    public decimal TotalAmount { get; init; }
    public bool IsCancelled { get; init; }
}
