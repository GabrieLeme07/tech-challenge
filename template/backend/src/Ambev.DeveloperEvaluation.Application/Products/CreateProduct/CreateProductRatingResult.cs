namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public record CreateProductRatingResult
{
    public decimal Rate { get; init; }
    public int Count { get; init; }
}
