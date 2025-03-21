using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales;

public static class ApplyDiscount
{
    public static void ApplyDiscountRules(Sale sale, IEnumerable<Discount> discountRules)
    {
        var orderedRules = discountRules.OrderByDescending(r => r.MinQuantity);

        foreach (var item in sale.Items)
        {
            var rule = orderedRules.FirstOrDefault(r =>
                item.Quantity >= r.MinQuantity &&
                (!r.MaxQuantity.HasValue || item.Quantity <= r.MaxQuantity.Value));

            if (rule != null)
            {
                item.ApplyDiscount(rule.Percentage);
            }
            else
            {
                item.ApplyDiscount(0);
            }
        }
    }
}
