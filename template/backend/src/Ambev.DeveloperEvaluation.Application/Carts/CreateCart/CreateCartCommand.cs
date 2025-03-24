using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartCommand : IRequest<CreateCartResult>
{
    public Guid UserId { get; init; }
    public DateTime Date { get; init; }
    public List<CartProductCommand> Products { get; init; } = new List<CartProductCommand>();

    public ValidationResultDetail Validate()
    {
        var validator = new CreateCartCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
