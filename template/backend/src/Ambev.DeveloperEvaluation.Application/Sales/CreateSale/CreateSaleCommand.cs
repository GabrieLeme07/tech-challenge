using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public record CreateSaleCommand : IRequest<CreateSaleResult>
{
    public int CustomerId { get; init; }
    public int CartId { get; init; }
    public string Branch { get; init; }
}
