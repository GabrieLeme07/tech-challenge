using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

/// <summary>
/// Validator for UpdateProductCommand that defines validation rules for user creation command.
/// </summary>
public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    /// <summary>
    /// Initializes a new instance of the UpdateProductCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Title: Cannot be Empty
    /// - Price: Greater Than 0
    /// - Description: Cannot be Empty
    /// - Category: Cannot be Empty
    /// </remarks>
    public UpdateProductCommandValidator()
    {
        RuleFor(product => product.Title).NotEmpty();
        RuleFor(product => product.Price).GreaterThan(0);
        RuleFor(product => product.Description).NotEmpty();
        RuleFor(product => product.Category).NotEmpty();
    }
}
