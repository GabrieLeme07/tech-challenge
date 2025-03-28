﻿namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

public class UpdateProductResponse
{
    public int Id { get; init; }
    public string Title { get; init; }
    public decimal Price { get; init; }
    public string Description { get; init; }
    public string Category { get; init; }
    public string Image { get; init; }
}
