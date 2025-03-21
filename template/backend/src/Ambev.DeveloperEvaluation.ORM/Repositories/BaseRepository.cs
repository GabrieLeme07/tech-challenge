using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public abstract class BaseRepository : IDisposable
{
    public BaseRepository(DefaultContext context)
    => Db = context;


    protected async virtual Task AddAsync<TEntity>(TEntity entity)
        => await Db.AddAsync(entity);

    protected virtual void Update<TEntity>(TEntity entity)
        => Db.Update(entity);


    /// <summary>
    /// Project Data context
    /// </summary>
    protected readonly DefaultContext Db;

    /// <summary>
    /// Unit Of Work
    /// </summary>
    public IUnitOfWork UnitOfWork => Db;

    public virtual void Dispose()
        => Db.Dispose();
}
