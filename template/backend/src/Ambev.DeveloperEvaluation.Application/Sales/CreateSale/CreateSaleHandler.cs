using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleHandler(ISaleRepository saleRepository, IDiscountRepository discountRepository, IMapper mapper) : CommandHandler, IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository = saleRepository;
    private readonly IDiscountRepository _discountRepository = discountRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var activeDiscounts = await _discountRepository.GetAllAsync();
        var activeDiscountRules = activeDiscounts.Where(d => d.IsActive);

        var sale = _mapper.Map<Sale>(request);

        ApplyDiscount.ApplyDiscountRules(sale, activeDiscountRules);

        var createdSale = await _saleRepository.CreateAsync(sale);

        cancellationToken.ThrowIfCancellationRequested();
        var commitResponse = await Commit(_saleRepository.UnitOfWork);

        if (!commitResponse.IsValid)
            throw new ValidationException(commitResponse.Errors);

        var result = _mapper.Map<CreateSaleResult>(createdSale);
        return result;
    } 
}
