namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

public record GetProductResponse
{
    public string Title { get; init; }
    public decimal Price { get; init; }
    public int Quantity { get; init; }
    public string Category { get; init; }
    public string Image { get; init; }
    public GetProductRatingResponse Rating { get; init; }
}
