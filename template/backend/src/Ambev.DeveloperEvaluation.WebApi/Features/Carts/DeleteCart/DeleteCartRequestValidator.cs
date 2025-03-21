﻿using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.DeleteCart;

public class DeleteCartRequestValidator : AbstractValidator<DeleteCartRequest>
{
    public DeleteCartRequestValidator()
    {
            RuleFor(cart => cart.Id)
                .NotEmpty()
                .WithMessage("Cart ID is required");
    }
}
