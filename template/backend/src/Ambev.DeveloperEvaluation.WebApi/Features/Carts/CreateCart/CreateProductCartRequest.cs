namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public record CreateProductCartRequest
{
    public Guid ProductId { get; init; }
    public int Quantity { get; init; }
}
