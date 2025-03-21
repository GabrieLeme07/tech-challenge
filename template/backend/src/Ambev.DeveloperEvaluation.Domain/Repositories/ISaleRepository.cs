using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ISaleRepository : IRepository<Sale>
{
    Task<Sale> CreateAsync(Sale entity);
    Task<bool> UpdatedAsync(Sale entity);
    Task<Sale> GetByIdAsync(int id);
    Task<List<Sale>> GetAllAsync(int take, int skip);
    Task<bool> DeleteAsync(int id);
}
