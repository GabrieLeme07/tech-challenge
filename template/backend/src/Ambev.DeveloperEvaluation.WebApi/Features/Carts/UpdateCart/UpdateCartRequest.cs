namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

public record UpdateCartRequest
{
    public Guid UserId { get; init; }
    public DateTime Date { get; init; }
    public List<UpdateProductCartRequest> ProductCarts { get; init; } = new List<UpdateProductCartRequest>();
}
