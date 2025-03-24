using Ambev.DeveloperEvaluation.Application.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetListProduct;

public class GetListProductCommand : IRequest<ListProductResult>
{
    public GetListProductCommand(Query query)
    {
        Query = query;
    }

    public Query Query { get; init; }
}
