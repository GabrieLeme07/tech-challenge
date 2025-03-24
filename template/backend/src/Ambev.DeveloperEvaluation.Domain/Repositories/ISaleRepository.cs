using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ISaleRepository : IRepository<Sale>
{
    Task<Sale> CreateAsync(Sale entity);
    void UpdatedAsync(Sale entity);
    Task<Sale> GetByIdAsync(Guid id);
    Task<bool> DeleteAsync(Guid id);
}
