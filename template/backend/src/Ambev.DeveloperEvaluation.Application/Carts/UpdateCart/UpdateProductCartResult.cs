namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

public record UpdateProductCartResult
{
    public Guid ProductId { get; init; }
    public int Quantity { get; init; }
}
