using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public class CreateProductHandler(IProductRepository repository, IMapper mapper) : CommandHandler, IRequestHandler<CreateProductCommand, CreateProductResult>
{
    private readonly IProductRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateProductCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var product = _mapper.Map<Product>(request);

        var createdProduct = await _repository.CreateAsync(product);

        cancellationToken.ThrowIfCancellationRequested();
        var commitResponse = await Commit(_repository.UnitOfWork);

        if (!commitResponse.IsValid)
            throw new ValidationException(commitResponse.Errors);
        var result = _mapper.Map<CreateProductResult>(createdProduct);
        return result;
    }
}