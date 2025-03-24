using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Domain.Bus;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleHandler(
    ISaleRepository saleRepository,
    ICartRepository cartRepository,
    IDiscountRepository discountRepository,
    IMessageHandler messageHandler,
    IMapper mapper)
    : CommandHandler, IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository = saleRepository;
    private readonly ICartRepository _cartRepository = cartRepository;
    private readonly IMessageHandler _messageHandler = messageHandler;
    private readonly IDiscountRepository _discountRepository = discountRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var cart = await _cartRepository.GetByIdAsync(request.CartId) ?? throw new ValidationException("Cart was not found");

        var groupedCartProducts = cart.Products
            .GroupBy(p => p.ProductId)
            .Select(g => new
            {
                g.First().Product,
                TotalQuantity = g.Sum(p => p.Quantity)
            })
            .ToList();

        if (groupedCartProducts.Any(x => x.TotalQuantity >= 20))
            throw new ValidationException("Não é permitido comprar 20 ou mais produtos iguais.");

        var saleItems = groupedCartProducts.Select(g => new SaleItem
        {
            ProductId = g.Product.Id,
            ProductDescription = g.Product.Title,
            Quantity = g.TotalQuantity,
            Price = g.Product.Price
        }).ToList();

        var sale = new Sale
        {
            SaleNumber = Guid.NewGuid().ToString(),
            CustomerId = cart.UserId.ToString(),
            BranchId = "defaultBranchId",
            BranchName = "defaultBranch",
            Items = saleItems
        };

        var activeDiscounts = await _discountRepository.GetAllAsync();
        var activeDiscountRules = activeDiscounts.Where(d => d.IsActive);

        ApplyDiscount.ApplyDiscountRules(sale, activeDiscountRules);

        var createdSale = await _saleRepository.CreateAsync(sale);

        cancellationToken.ThrowIfCancellationRequested();
        var commitResponse = await Commit(_saleRepository.UnitOfWork);

        if (!commitResponse.IsValid)
            throw new ValidationException(commitResponse.Errors);

        _ = HandlerMessages(sale.SaleNumber, cart.UserId);
        var result = _mapper.Map<CreateSaleResult>(createdSale);
        return result;
    }

    private async Task HandlerMessages(string saleNumber, Guid customerId)
    {
        await _messageHandler.Publish(new ProcessSalePaymentEvent(saleNumber));
        await _messageHandler.Publish(new SaleNotificationEvent(saleNumber, customerId));
    }
}
