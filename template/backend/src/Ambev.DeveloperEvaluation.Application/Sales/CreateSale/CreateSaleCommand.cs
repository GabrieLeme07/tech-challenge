using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    public Guid CustomerId { get; init; }
    public Guid CartId { get; init; }
    public string Branch { get; init; }
}
