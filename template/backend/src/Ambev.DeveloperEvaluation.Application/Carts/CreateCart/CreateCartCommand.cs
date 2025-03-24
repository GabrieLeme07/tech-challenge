using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

/// <summary>
/// Command for creating a new Cart.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a Cart, 
/// including UserId, Date amd Products. 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="CreateUserResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="CreateCartCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public record CreateCartCommand : IRequest<CreateCartResult>
{
    /// <summary>
    /// Gets or sets the UserId of the Cart to be created.
    /// </summary>
    public int UserId { get; init; }

    /// <summary>
    /// Gets or sets the Date of the Cart to be created.
    /// </summary>
    public DateTime Date { get; init; }

    /// <summary>
    /// Gets or sets the Products of the Cart to be created.
    /// </summary>
    public List<CartProductCommand> Products { get; init; }

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
