using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Common.Extensions;
using Ambev.DeveloperEvaluation.Common.Ordering;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class ProductRepository : BaseRepository, IProductRepository
{
    public ProductRepository(DefaultContext context) : base(context) { }

    public async Task<Product> CreateAsync(Product entity)
    {
        await base.AddAsync(entity);
        return entity;
    }

    public void UpdatedAsync(Product entity)
        => base.Update(entity);

    public async Task<Product?> GetByIdAsync(int id)
        => await Db.Products.FirstOrDefaultAsync(e => e.Id == id);

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await GetByIdAsync(id);
        if (product == null)
            return false;

        Db.Products.Remove(product);
        return true;
    }

    public async Task<List<Product>> GetAllAsync(Query query)
    {
        var queryable = Db.Products
            .AsNoTracking()
            .Include(p => p.Rating)

            // Filters
            .ConditionalWhere(e => e.Title.Contains(query.Search) || e.Category.Contains(query.Search), query.HasSearch)

            // Sorting 
            .ApplyOrdering(query.OrderBy)

            // Paging 
            .ApplyPaging(query.IsPaginated, query.Skip, query.Take);

        return await queryable.ToListAsync();
    }
}
