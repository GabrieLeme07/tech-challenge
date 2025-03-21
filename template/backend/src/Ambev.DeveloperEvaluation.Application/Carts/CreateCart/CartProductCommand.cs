namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CartProductCommand
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
