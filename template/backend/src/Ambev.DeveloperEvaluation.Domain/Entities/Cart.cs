using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Cart : BaseEntity
{
    public DateTime Date { get; init; }
    public IEnumerable<CartProduct> Products { get; init; }

    public int UserId { get; init; }
    public User User { get; init; }
}
