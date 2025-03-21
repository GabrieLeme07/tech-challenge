namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;

public class CreateCartRequest
{
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public List<CreateProductCartRequest> ProductCarts { get; set; } = new List<CreateProductCartRequest>();
}
