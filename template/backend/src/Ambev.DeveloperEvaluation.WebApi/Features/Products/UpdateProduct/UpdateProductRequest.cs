namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

public record UpdateProductRequest
{
    public string Title { get; init; }
    public decimal Price { get; init; }
    public string Description { get; init; }
    public string Category { get; init; }
    public string Image { get; init; }
    public UpdateProductRatingRequest Rating { get; init; }
}
