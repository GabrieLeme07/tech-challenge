using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class SaleRepository : ISaleRepository
{
    public IUnitOfWork UnitOfWork => throw new NotImplementedException();

    public Task<Sale> CreateAsync(Sale entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Task<List<Sale>> GetAllAsync(int take, int skip)
    {
        throw new NotImplementedException();
    }

    public Task<Sale> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdatedAsync(Sale entity)
    {
        throw new NotImplementedException();
    }
}
