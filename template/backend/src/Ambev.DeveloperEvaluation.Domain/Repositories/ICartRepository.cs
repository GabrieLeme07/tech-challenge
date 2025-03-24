using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ICartRepository : IRepository<Cart>
{
    Task<Cart> CreateAsync(Cart entity);
    void UpdatedAsync(Cart entity);
    Task<Cart> GetByIdAsync(Guid id);
    Task<List<Cart>> GetAllAsync(Query query);
    Task<bool> DeleteAsync(Guid id);
}
