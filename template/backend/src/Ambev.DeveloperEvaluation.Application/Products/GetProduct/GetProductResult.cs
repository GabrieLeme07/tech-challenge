namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

public record GetProductResult
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public decimal Price { get; init; }
    public int Quantity { get; init; }
    public string Category { get; init; }
    public string Image { get; init; }
    public GetProductRatingResult Rating { get; init; }
}
