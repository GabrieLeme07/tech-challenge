using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface IDiscountRepository
{
    Task<Discount> CreateAsync(Discount entity);
    Task<Discount> GetByIdAsync(int id);
    Task<List<Discount>> GetAllAsync(int take, int skip);
}
