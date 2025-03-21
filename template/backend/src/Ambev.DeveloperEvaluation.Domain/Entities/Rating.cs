using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Rating: BaseEntity
{
    public float Rate { get; init; }
    public int Count { get; init; }
}
