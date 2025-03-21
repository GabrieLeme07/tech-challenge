using Ambev.DeveloperEvaluation.WebApi.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCarts
{
    public class GetCartsResponse : PaginatedResponse<GetCartsResponse>
    {
        public int Id { get; init; }
        public Guid UserId { get; init; }
        public DateTime Date { get; init; }
        public List<GetProductCartResponse> ProductCarts { get; set; } = new List<GetProductCartResponse>();
    }
}
