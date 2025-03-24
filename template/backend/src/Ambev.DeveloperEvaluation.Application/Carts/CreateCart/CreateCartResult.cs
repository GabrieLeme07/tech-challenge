namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public record CreateCartResult
{
    public int Id { get; init; }
    public int UserId { get; init; }
    public DateTime Date { get; init; }
    public List<CreateProductCartResult> ProductCarts { get; init; }
}
