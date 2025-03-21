using Ambev.DeveloperEvaluation.Application.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

public class GetProductCommand : IRequest<GetProductResult>
{
    public GetProductCommand(int id, Query query)
    {
        Id = id;
        Query = query;
    }

    public int Id { get; set; }
    public Query Query { get; set; }
}
