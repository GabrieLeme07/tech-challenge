﻿namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

public record UpdateProductCartResult
{
    public int ProductId { get; init; }
    public int Quantity { get; init; }
}
