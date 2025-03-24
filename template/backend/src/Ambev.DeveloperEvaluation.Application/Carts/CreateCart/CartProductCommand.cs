namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public record CartProductCommand
{
    public Guid ProductId { get; init; }
    public int Quantity { get; init; }
}
