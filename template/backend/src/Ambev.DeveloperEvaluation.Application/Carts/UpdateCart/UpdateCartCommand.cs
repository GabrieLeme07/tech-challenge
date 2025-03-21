using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart
{
    public class UpdateCartCommand : IRequest<UpdateCartResult>
    {
        public Guid UserId { get; init; }
        public DateTime Date { get; init; }
        public List<UpdateProductCartCommand> ProductCarts { get; init; } = new List<UpdateProductCartCommand>();

        public ValidationResultDetail Validate()
        {
            var validator = new UpdateCartCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
