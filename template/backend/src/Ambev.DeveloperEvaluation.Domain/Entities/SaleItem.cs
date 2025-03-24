using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class SaleItem : BaseEntity
{
    public Guid ProductId { get; init; }
    public string ProductDescription { get; init; }
    public int Quantity { get; init; }
    public decimal Price { get; init; }
    public decimal DiscountPercentage { get; private set; }
    public decimal TotalAmount { get; private set; }
    public bool Cancelled { get; init; }

    public void ApplyDiscount(decimal discountPercentage)
    {
        DiscountPercentage = discountPercentage;
        TotalAmount = Price * Quantity * (1 - (discountPercentage / 100));
    }
}
