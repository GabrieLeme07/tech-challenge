using System.Linq.Dynamic.Core;

namespace Ambev.DeveloperEvaluation.Common.Ordering;

public static class IQueryableExtensions
{
    public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> source, string orderBy)
    {
        if (string.IsNullOrWhiteSpace(orderBy))
            return source;

        var orderByExpression = orderBy.Replace('|', ',');

        return DynamicQueryableExtensions.OrderBy(source, orderByExpression);
    }

    public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> source, bool isPaginated, int skip, int take)
    {
        if (!isPaginated)
            return source;

        return source
            .Skip(skip)
            .Take(take);
    }
}
