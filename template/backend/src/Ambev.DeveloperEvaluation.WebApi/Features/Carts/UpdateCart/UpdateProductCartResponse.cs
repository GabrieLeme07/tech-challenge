namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

public record UpdateProductCartResponse
{
    public Guid ProductId { get; init; }
    public int Quantity { get; init; }
}
