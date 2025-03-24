using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

public class UpdateProductHandler(IProductRepository repository, IMapper mapper) : CommandHandler, IRequestHandler<UpdateProductCommand, UpdateProductResult>
{
    private readonly IProductRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<UpdateProductResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateProductCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var product = _mapper.Map<Product>(request);

        _repository.UpdatedAsync(product);

        cancellationToken.ThrowIfCancellationRequested();
        var commitResponse = await Commit(_repository.UnitOfWork);

        if (!commitResponse.IsValid)
            throw new ValidationException(commitResponse.Errors);

        return _mapper.Map<UpdateProductResult>(product);
    }
}
