using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for Cart entity operations
/// </summary>
public interface ICartRepository : IRepository<Cart>
{
    /// <summary>
    /// Creates a new Cart in the repository
    /// </summary>
    /// <param name="entity">The Cart to create</param>
    Task<Cart> CreateAsync(Cart entity);

    /// <summary>
    /// Update a Cart
    /// </summary>
    /// <param name="entity">The Cart to update</param>
    void UpdatedAsync(Cart entity);

    /// <summary>
    /// Retrieves a Cart by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the Cart</param>
    /// <returns>The Cart if found, null otherwise</returns>
    Task<Cart> GetByIdAsync(int id);

    /// <summary>
    /// Retrieves all Cart
    /// </summary>
    /// <param name="query">The query to search for</param>
    Task<List<Cart>> GetAllAsync(Query query);

    /// <summary>
    /// Retrieves a Cart by their email address
    /// </summary>
    /// <param name="id">The unique identifier of the Cart</param>
    /// <returns>The Cart if found, null otherwise</returns>
    Task<bool> DeleteAsync(int id);
}
