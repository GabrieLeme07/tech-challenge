using Ambev.DeveloperEvaluation.Application.Carts.GetCart;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetListCart;

public class GetListCartHandler(ICartRepository cartRepository, IMapper mapper) : IRequestHandler<GetListCartCommand, ListCartResult>
{
    private readonly ICartRepository _repository = cartRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<ListCartResult> Handle(GetListCartCommand request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var product = await _repository.GetAllAsync(request.Query);

        return new ListCartResult
        {
            Carts = product.Select(p => _mapper.Map<GetCartResult>(p)).ToList(),
            Page = request.Query.Page,
            Size = request.Query.Take,
            Count = product.Count(),
        };
    }
}