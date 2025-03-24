using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale : BaseEntity
{
    public string SaleNumber { get; init; }
    public DateTime SaleDate { get; init; } = DateTime.UtcNow;

    public string CustomerId { get; init; }
    public string BranchId { get; init; }
    public string BranchName { get; init; }

    public SaleStatus Status { get; init; } = SaleStatus.CREATED;
    public IEnumerable<SaleItem> Items { get; init; }

    public decimal TotalAmount => Items.Sum(item => item.TotalAmount);
}
