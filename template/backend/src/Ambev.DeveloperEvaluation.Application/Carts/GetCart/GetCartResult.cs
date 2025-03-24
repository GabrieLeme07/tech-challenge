namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;
public record GetCartResult
{
    public int Id { get; init; }
    public int UserId { get; init; }
    public DateTime Date { get; init; }
    public List<GetCartProductResult> ProductCarts { get; init; }
}
