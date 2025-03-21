using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ICartRepository
{
    Task<Cart> CreateAsync(Cart entity);
    Task<bool> UpdatedAsync(Cart entity);
    Task<Cart> GetByIdAsync(int id);
    Task<List<Cart>> GetAllAsync(int take, int skip);
    Task<bool> DeleteAsync(int id);
}
