namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public class CreateCartResponse
{
    public int Id { get; init; }
    public Guid UserId { get; init; }
    public DateTime Date { get; init; }
    public List<CreateProductCartResponse> ProductCarts { get; set; } = new List<CreateProductCartResponse>();
}
