﻿using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart
{
    public class CreateCartRequestValidator : AbstractValidator<CreateCartRequest>
    {
        public CreateCartRequestValidator()
        {
            RuleFor(cart => cart.Products)
                 .NotEmpty();
        }
    }
}
