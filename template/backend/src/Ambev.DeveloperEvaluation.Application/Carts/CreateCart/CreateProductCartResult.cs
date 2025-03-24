namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public record CreateProductCartResult
{
    public int ProductId { get; init; }
    public int Quantity { get; init; }
}
