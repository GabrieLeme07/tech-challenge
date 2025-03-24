using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class DiscountRepository : IDiscountRepository
{
    public Task<Discount> CreateAsync(Discount entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Discount>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Discount> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
