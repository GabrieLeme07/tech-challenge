namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart
{
    public record UpdateCartResult
    {
        public int Id { get; init; }
        public int UserId { get; init; }
        public DateTime Date { get; init; }
        public List<UpdateProductCartResult> ProductCarts { get; init; }
    }
}
