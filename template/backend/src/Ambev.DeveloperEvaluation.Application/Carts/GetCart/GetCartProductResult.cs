namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

public record class GetCartProductResult
{
    public int ProductId { get; init; }
    public int Quantity { get; init; }
}
