using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

public class UpdateCartHandler(ICartRepository cartRepository, IMapper mapper) : CommandHandler, IRequestHandler<UpdateCartCommand, UpdateCartResult>
{
    private readonly ICartRepository _repository = cartRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<UpdateCartResult> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateCartCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var cart = _mapper.Map<Cart>(request);

        _repository.UpdatedAsync(cart);

        cancellationToken.ThrowIfCancellationRequested();
        var commitResponse = await Commit(_repository.UnitOfWork);

        if (!commitResponse.IsValid)
            throw new ValidationException(commitResponse.Errors);

        var result = _mapper.Map<UpdateCartResult>(cart);
        return result;
    }
}
