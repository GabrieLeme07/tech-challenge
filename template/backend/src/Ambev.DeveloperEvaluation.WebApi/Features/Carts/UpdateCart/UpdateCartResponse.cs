namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

public class UpdateCartResponse
{
    public int Id { get; init; }
    public Guid UserId { get; init; }
    public DateTime Date { get; init; }
    public List<UpdateProductCartResponse> ProductCarts { get; init; } = new List<UpdateProductCartResponse>();
}
