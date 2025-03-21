namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public record CreateProductCartResult
{
    public Guid ProductId { get; init; }
    public int Quantity { get; init; }
}
