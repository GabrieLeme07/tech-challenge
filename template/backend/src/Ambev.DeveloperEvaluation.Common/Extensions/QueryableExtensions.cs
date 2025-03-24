using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.Common.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<TEntity> ConditionalWhere<TEntity>(this IQueryable<TEntity> queryable, Expression<Func<TEntity, bool>> predicate, bool executeThis)
    {
        return executeThis
            ? queryable.Where(predicate)
            : queryable;
    }
}
