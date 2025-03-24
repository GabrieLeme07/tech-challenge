namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

public record GetProductRatingResult
{
    public Guid Id { get; init; }
    public float Rate { get; init; }
    public int Count { get; init; }
}
