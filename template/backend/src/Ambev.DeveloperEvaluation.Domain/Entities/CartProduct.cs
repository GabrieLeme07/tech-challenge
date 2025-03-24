using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class CartProduct : BaseEntity
{
    public int CartId { get; init; }
    public Cart Cart { get; init; }

    public int ProductId { get; init; }
    public Product Product { get; init; }
    public int Quantity { get; init; }
}