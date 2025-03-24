using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetListProduct;

public class GetListProductHandler(IProductRepository productRepository, IMapper mapper) : IRequestHandler<GetListProductCommand, ListProductResult>
{
    private readonly IProductRepository _repository = productRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<ListProductResult> Handle(GetListProductCommand request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var product = await _repository.GetAllAsync(request.Query);

        return new ListProductResult
        {
            Produtos = product.Select(p => _mapper.Map<GetProductResult>(p)).ToList(),
            Page = request.Query.Page,
            Size = request.Query.Take,
            Count = product.Count(),
        };
    }
}
