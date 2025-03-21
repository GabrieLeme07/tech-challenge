using Ambev.DeveloperEvaluation.Domain.Entities;
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

    public async Task<Cart?> GetByIdAsync(Guid id)
        => await Db.Carts.FirstOrDefaultAsync(e => e.Id == id);

    public async Task<List<Cart>> GetAllAsync(int take, int skip)
        => await _context.Carts.Skip(skip).Take(take).ToListAsync();

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var cart = await GetByIdAsync(id, cancellationToken);
        if (cart == null)
            return false;

        _context.Carts.Remove(cart);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
