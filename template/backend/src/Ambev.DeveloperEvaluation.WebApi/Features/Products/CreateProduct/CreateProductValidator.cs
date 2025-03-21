using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public class CreateProductValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductValidator()
    {
        RuleFor(product => product.Title)
            .Empty()
            .WithMessage($"The Title property can't be empty");

        RuleFor(product => product.Price)
            .LessThanOrEqualTo(0)
            .WithMessage($"The Unit Price can't be 0");

        RuleFor(product => product.Category)
            .Empty()
            .WithMessage($"The Category is required");
    }
}
