namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface IRepository<TEntity> : IRepository
{
    /// <summary>
    /// Unit Of Work
    /// </summary>
    IUnitOfWork UnitOfWork { get; }
}

public interface IRepository : IDisposable
{
}
