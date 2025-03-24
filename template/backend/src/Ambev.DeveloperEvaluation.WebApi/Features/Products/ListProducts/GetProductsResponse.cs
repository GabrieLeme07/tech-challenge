using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts;

public class GetProductsResponse : PaginatedResponse<GetProductsResponse>
{
    public string Title { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Total { get; set; }
    public decimal Discount { get; set; }
    public int Quantity { get; set; }
    public string Category { get; set; }
    public string Image { get; set; }
    public GetProductRatingResponse Rating { get; set; }
}
