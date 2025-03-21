using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCarts;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;

public class GetCartResponse
{
    public int Id { get; init; }
    public Guid UserId { get; init; }
    public DateTime Date { get; init; }
    public List<GetProductCartResponse> ProductCarts { get; init; } = new List<GetProductCartResponse>();
}
