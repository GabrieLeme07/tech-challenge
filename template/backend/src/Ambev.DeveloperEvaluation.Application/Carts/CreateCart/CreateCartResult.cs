namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartResult
{
    public int Id { get; init; }
    public Guid UserId { get; init; }
    public DateTime Date { get; init; }
    public List<CreateProductCartResult> ProductCarts { get; init; } = new List<CreateProductCartResult>(); 
}
