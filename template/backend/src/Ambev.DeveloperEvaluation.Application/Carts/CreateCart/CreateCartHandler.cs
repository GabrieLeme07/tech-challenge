using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartHandler(ICartRepository cartRepository, IMapper mapper) : CommandHandler, IRequestHandler<CreateCartCommand, CreateCartResult>
{
    private readonly ICartRepository _repository = cartRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<CreateCartResult> Handle(CreateCartCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateCartCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var cart = _mapper.Map<Cart>(request);

        var createdCart = await _repository.CreateAsync(cart);

        cancellationToken.ThrowIfCancellationRequested();
        var commitResponse = await Commit(_repository.UnitOfWork);

        if (!commitResponse.IsValid)
            throw new ValidationException(commitResponse.Errors);

        var result = _mapper.Map<CreateCartResult>(createdCart);
        return result;
    }
}
