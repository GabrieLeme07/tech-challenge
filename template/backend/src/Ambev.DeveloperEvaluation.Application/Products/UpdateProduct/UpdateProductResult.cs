namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

public record UpdateProductResult
{
    public int Id { get; init; }
    public string Title { get; init; }
    public decimal UnitPrice { get; init; }
    public decimal Total { get; init; }
    public decimal Discount { get; init; }
    public int Quantity { get; init; }
    public string Category { get; init; }
    public string Image { get; init; }
    public UpdateProductRatingResult Rating { get; init; }
}
