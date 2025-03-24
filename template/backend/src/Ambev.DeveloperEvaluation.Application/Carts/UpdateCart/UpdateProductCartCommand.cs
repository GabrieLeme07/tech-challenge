namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

public record UpdateProductCartCommand
{
    public int ProductId { get; init; }
    public int Quantity { get; init; }
}
