using Ambev.DeveloperEvaluation.Application.Products.GetProduct;

namespace Ambev.DeveloperEvaluation.Application.Products.GetListProduct;

public class ListProductResult
{
    public List<GetProductResult> Produtos { get; set; } = new List<GetProductResult>();
    public int Page { get; set; }
    public int Size { get; set; }
    public int Count { get; set; }
}
