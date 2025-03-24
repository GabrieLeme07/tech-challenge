using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public record UpdateSaleResult
{
    public int Id { get; init; }
    public DateTime Date { get; init; }
    public Guid CustomerId { get; init; }
    public decimal TotalAmount { get; init; }
    public string BranchSaleWasMade { get; init; } 
    public List<UpdateProductCommand> Products { get; init; }
    public SaleStatus Status { get; init; }
}
