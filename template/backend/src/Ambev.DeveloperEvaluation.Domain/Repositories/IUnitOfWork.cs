namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface IUnitOfWork
{
    Task<bool> Commit();
}
