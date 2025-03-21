namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

public class UpdateProductCartCommand
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
