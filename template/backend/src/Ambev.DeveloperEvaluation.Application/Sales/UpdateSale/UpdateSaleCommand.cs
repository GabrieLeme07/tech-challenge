using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public record UpdateSaleCommand : IRequest<UpdateSaleResult>
{
    public DateTime Date { get; init; }
    public Guid CustomerId { get; init; }
    public decimal TotalAmount { get; init; }
    public string BranchSaleWasMade { get; init; }
    public List<CreateProductCommand> Products { get; init; }
    public SaleStatus Status { get; init; }
}
