using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Discount : BaseEntity
{
    public int MinQuantity { get; init; }
    public int? MaxQuantity { get; init; }
    public decimal Percentage { get; init; }
    public bool IsActive { get; init; }
}
