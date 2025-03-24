using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class SaleRepository : BaseRepository, ISaleRepository
{
    public SaleRepository(DefaultContext context) : base(context) { }

    public async Task<Sale> CreateAsync(Sale entity)
    {
        await base.AddAsync(entity);
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var sale = await GetByIdAsync(id);
        if (sale == null)
            return false;

        Db.Sales.Remove(sale);
        return true;
    }

    public async Task<Sale?> GetByIdAsync(int id)
        => await Db
        .Sales
        .Include(c => c.Items)
        .FirstOrDefaultAsync(e => e.Id == id);

    public void UpdatedAsync(Sale entity)
            => base.Update(entity);
}
