using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Common.Ordering;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class CartRepository : BaseRepository, ICartRepository
{
    public CartRepository(DefaultContext context) : base(context) { }

    public async Task<Cart> CreateAsync(Cart entity)
    {
        await base.AddAsync(entity);
        return entity;
    }

    public void UpdatedAsync(Cart entity)
        => base.Update(entity);

    public async Task<Cart?> GetByIdAsync(int id)
        => await Db
        .Carts
        .Include(c => c.Products)
        .ThenInclude(c => c.Product)
        .FirstOrDefaultAsync(e => e.Id == id);

    public async Task<List<Cart>> GetAllAsync(Query query)
    {
        var queryable = Db.Carts
            .AsNoTracking()
            .Include(e => e.Products)
            .ApplyOrdering(query.OrderBy)
            .ApplyPaging(query.IsPaginated, query.Skip, query.Take);

        return await queryable.ToListAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var cart = await GetByIdAsync(id);
        if (cart == null)
            return false;

        Db.Carts.Remove(cart);
        return true;
    }
}
