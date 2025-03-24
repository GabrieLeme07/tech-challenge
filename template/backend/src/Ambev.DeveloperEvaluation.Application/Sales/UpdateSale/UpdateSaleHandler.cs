using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleHandler(ISaleRepository saleRepository, IDiscountRepository discountRepository, IMapper mapper) : CommandHandler, IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly ISaleRepository _saleRepository = saleRepository;
    private readonly IDiscountRepository _discountRepository = discountRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var activeDiscounts = await _discountRepository.GetAllAsync();
        var activeDiscountRules = activeDiscounts.Where(d => d.IsActive);

        var sale = _mapper.Map<Sale>(request);
        ApplyDiscount.ApplyDiscountRules(sale, activeDiscountRules);

        _saleRepository.UpdatedAsync(sale);

        cancellationToken.ThrowIfCancellationRequested();
        var commitResponse = await Commit(_saleRepository.UnitOfWork);

        if (!commitResponse.IsValid)
            throw new ValidationException(commitResponse.Errors);

        var result = _mapper.Map<UpdateSaleResult>(sale);
        return result;
    }
}
