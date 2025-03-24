using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    const string ShortDateFormat = "d";
    public CreateSaleRequestValidator()
    {
        RuleFor(sale => sale.Branch)
             .NotEmpty()
            .WithMessage($"The Branch property can't be empty");

        RuleFor(sale => sale.CustomerId)
            .NotEmpty()
            .WithMessage($"The {nameof(User)} {nameof(User.Id)} property is required");

    }
}
