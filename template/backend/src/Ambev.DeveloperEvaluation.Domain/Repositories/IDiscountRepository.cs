using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface IDiscountRepository
{
    Task<Discount> CreateAsync(Discount entity);
    Task<Discount> GetByIdAsync(Guid id);
    Task<IEnumerable<Discount>> GetAllAsync();
}
