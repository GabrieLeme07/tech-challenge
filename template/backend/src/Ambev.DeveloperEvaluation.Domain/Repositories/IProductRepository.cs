using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for Product entity operations
/// </summary>
public interface IProductRepository : IRepository<Product>
{
    /// <summary>
    /// Creates a new Product in the repository
    /// </summary>
    /// <param name="entity">The Product to create</param>
    Task<Product> CreateAsync(Product entity);

    /// <summary>
    /// Update a Product
    /// </summary>
    /// <param name="entity">The Product to update</param>
    void UpdatedAsync(Product entity);

    /// <summary>
    /// Retrieves a Product by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the Product</param>
    /// <returns>The Product if found, null otherwise</returns>
    Task<Product> GetByIdAsync(int id);

    /// <summary>
    /// Retrieves all Product
    /// </summary>
    /// <param name="query">The query to search for</param>
    /// <returns>The user if found, null otherwise</returns>
    Task<List<Product>> GetAllAsync(Query query);

    /// <summary>
    /// Retrieves a product by their email address
    /// </summary>
    /// <param name="id">The unique identifier of the Product</param>
    /// <returns>The product if found, null otherwise</returns>
    Task<bool> DeleteAsync(int id);
}
