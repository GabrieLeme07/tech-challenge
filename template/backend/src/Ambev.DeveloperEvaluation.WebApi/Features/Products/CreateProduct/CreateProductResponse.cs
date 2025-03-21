namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public record CreateProductResponse
{
    public int Id { get; init; }
    public string Title { get; init; }
    public decimal Price { get; init; }
    public decimal Description { get; init; }
    public string Category { get; init; } 
    public string Image { get; init; } 
    public CreateProductRatingResponse Rating { get; init; }
}
