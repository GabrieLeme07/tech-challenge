namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

public record GetProductRatingResponse
{
    public float Rate { get; init; }
    public int Count { get; init; }
}
