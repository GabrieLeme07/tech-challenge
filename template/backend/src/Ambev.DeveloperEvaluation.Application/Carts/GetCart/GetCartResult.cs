namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;
public class GetCartResult
{
    public int Id { get; init; }
    public Guid UserId { get; init; }
    public DateTime Date { get; init; }
    public List<GetCartProductResult> ProductCarts { get; init; } = new List<GetCartProductResult>();
}
