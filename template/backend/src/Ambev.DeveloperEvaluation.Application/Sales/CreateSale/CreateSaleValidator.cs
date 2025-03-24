﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    private const string ShortDateFormat = "d";
    public CreateSaleCommandValidator()
    {
        RuleFor(sale => sale.BranchSaleWasMade)
            .Equal(string.Empty)
            .WithMessage($"");

        RuleFor(sale => sale.InitialDate)
            .Equal(DateTime.MinValue)
            .WithMessage($"The Date property can't be {DateTime.MinValue.ToString(ShortDateFormat)}");

        RuleFor(sale => sale.InitialDate)
            .Equal(DateTime.MaxValue)
            .WithMessage($"The Date property can't be {DateTime.MaxValue.ToString(ShortDateFormat)}");

        RuleFor(sale => sale.CustomerId)
            .NotEmpty()
            .WithMessage($"The {nameof(User)} {nameof(User.Id)} property is required");

        RuleFor(sale => sale.TotalAmount)
            .Equal(decimal.Zero)
            .WithMessage($"The {nameof(Sale)} {nameof(Sale.TotalAmount)} property can't be 0");
    }
}
