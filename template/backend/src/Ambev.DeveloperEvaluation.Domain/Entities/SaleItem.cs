using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class SaleItem : BaseEntity
{
    public string ProductId { get; private set; }
    public string ProductDescription { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal DiscountPercentage { get; private set; }
    public decimal TotalAmount { get; private set; }
    public bool Cancelled { get; private set; }

    public SaleItem(string productId, string productDescription, int quantity, decimal unitPrice, decimal discountPercent)
    {
        if (quantity > 20)
            throw new ArgumentException("Não é permitido vender mais de 20 itens idênticos.");

        ProductId = productId;
        ProductDescription = productDescription;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Cancelled = false;

        DiscountPercentage = discountPercent;
        TotalAmount = Quantity * UnitPrice * (1 - DiscountPercentage);
    }

    public void CancelItem()
    {
        Cancelled = true;
    }
}
