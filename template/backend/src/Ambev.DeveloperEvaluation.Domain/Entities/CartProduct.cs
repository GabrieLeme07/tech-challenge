using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class CartProduct : BaseEntity
{
    public Guid CartId { get; init; }
    public Cart Cart { get; init; }

    public Guid ProductId { get; init; }
    public int Quantity { get; init; }
}