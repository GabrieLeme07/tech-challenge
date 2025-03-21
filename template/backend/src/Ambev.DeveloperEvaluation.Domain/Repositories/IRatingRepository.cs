using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface IRatingRepository
{
    Task<Rating> CreateAsync(Rating entity);
    Task<bool> UpdatedAsync(Rating entity);
    Task<Rating> GetByIdAsync(int id);
    Task<List<Rating>> GetAllAsync(int take, int skip);
    Task<bool> DeleteAsync(int id);
}
