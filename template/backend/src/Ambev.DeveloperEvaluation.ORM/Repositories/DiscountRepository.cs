using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class DiscountRepository : BaseRepository, IDiscountRepository
{
    public DiscountRepository(DefaultContext context) : base(context) { }

    public async Task<Discount> CreateAsync(Discount entity)
    {
        await base.AddAsync(entity);
        return entity;
    }

    public async Task<IEnumerable<Discount>> GetAllAsync()
    {
        var queryable = Db.Discounts
            .AsNoTracking();

        return await queryable.ToListAsync();
    }

    public async Task<Discount?> GetByIdAsync(Guid id)
        => await Db
        .Discounts
        .FirstOrDefaultAsync(e => e.Id == id);
}
