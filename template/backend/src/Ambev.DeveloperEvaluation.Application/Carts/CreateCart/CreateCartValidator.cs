using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
{
    public CreateCartCommandValidator()
    {
        RuleFor(cart => cart.UserId)
            .NotEqual(Guid.Empty)
            .WithMessage("The property User ID can't be empty");
        
        RuleFor(cart => cart.Products)
            .NotEmpty()
            .WithMessage("The products are required"); 
    }
}
