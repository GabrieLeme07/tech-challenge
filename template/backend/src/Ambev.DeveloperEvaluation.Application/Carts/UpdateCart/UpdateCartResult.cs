namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart
{
    public class UpdateCartResult
    {
        public int Id { get; init; }
        public Guid UserId { get; init; }
        public DateTime Date { get; init; }
        public List<UpdateProductCartResult> ProductCarts { get; init; } = new List<UpdateProductCartResult>();
    }
}
