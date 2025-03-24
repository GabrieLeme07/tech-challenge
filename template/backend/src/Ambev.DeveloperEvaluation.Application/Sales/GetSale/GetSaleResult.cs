using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Domain.Enums; 
namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public record GetSaleResult
{
    public int Id { get; init; }
    public DateTime Date { get; init; }
    public int CustomerId { get; init; }
    public decimal TotalAmount { get; init; }
    public string BranchSaleWasMade { get; init; }
    public List<CreateProductCommand> Products { get; init; }
    public SaleStatus Status { get; init; }
}
