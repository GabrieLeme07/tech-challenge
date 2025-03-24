using Ambev.DeveloperEvaluation.Application.Carts.GetCart;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetListCart;

public record ListCartResult
{
    public List<GetCartResult> Carts { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
    public int Count { get; set; }
}
