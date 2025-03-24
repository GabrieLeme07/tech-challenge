using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

public class UpdateProductValidator : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductValidator()
    {
        RuleFor(product => product.Title)
            .Equal(string.Empty)
            .WithMessage($"The Title property can't be empty");

        RuleFor(product => product.Category)
            .Equal(string.Empty)
            .WithMessage($"The Category is required");
    }
}
