using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Product : BaseEntity
{
    public string Title { get; init; }
    public string Category { get; init; }
    public string Image { get; init; }
    public int Quantity { get; init; }
    public decimal Price { get; init; }

    public int RatingId { get; init; }
    public Rating Rating { get; init; }
}
