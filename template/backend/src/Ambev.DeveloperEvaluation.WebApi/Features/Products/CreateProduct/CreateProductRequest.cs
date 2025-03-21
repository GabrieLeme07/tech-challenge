namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public record CreateProductRequest
{
    public string Title { get; init; } 
    public decimal Price { get; init; }
    public string Description { get; init; } 
    public string Category { get; init; } 
    public string Image { get; init; } 
    public CreateProductRatingRequest Rating { get; init; }
}
