using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    private const string ShortDateFormat = "d";
    public CreateSaleCommandValidator()
    {
        RuleFor(sale => sale.Branch)
            .NotEmpty();

        RuleFor(sale => sale.CustomerId)
            .NotEmpty()
            .WithMessage($"The {nameof(Sale)} {nameof(Sale.CustomerId)} property is required");

        RuleFor(sale => sale.CartId)
            .NotEmpty()
            .WithMessage($"The {nameof(Sale)} CartId property can't be 0");
    }
}
