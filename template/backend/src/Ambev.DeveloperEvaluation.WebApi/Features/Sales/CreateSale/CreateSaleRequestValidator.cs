using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    const string ShortDateFormat = "d";
    public CreateSaleRequestValidator()
    {  
        RuleFor(sale => sale.Branch)
             .Empty()
            .WithMessage($"The Branch property can't be empty");

        RuleFor(sale => sale.Date)
            .Equal(DateTime.MinValue)
            .WithMessage($"The Date property can't be {DateTime.MinValue.ToString(ShortDateFormat)}");

        RuleFor(sale => sale.CustomerId)
            .NotEmpty()
            .WithMessage($"The {nameof(User)} {nameof(User.Id)} property is required");

        RuleFor(sale => sale.Products)
            .Must(products => products.All(p => p.Quantity <= 20))
            .WithMessage("A product cannot have more than 20 units.");
    }
}
