namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public record ProductRatingCommand
{
    public decimal Rate { get; init; }
    public int Count { get; init; }
}

