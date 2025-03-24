using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for Sale entity operations
/// </summary>
public interface ISaleRepository : IRepository<Sale>
{
    /// <summary>
    /// Creates a new Sale in the repository
    /// </summary>
    /// <param name="entity">The Sale to create</param>
    Task<Sale> CreateAsync(Sale entity);

    /// <summary>
    /// Update a Sale
    /// </summary>
    /// <param name="entity">The Sale to update</param>
    void UpdatedAsync(Sale entity);

    /// <summary>
    /// Retrieves a Sale by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the Sale</param>
    /// <returns>The Sale if found, null otherwise</returns>
    Task<Sale> GetByIdAsync(int id);

    /// <summary>
    /// Retrieves a sale by their email address
    /// </summary>
    /// <param name="id">The unique identifier of the sale</param>
    /// <returns>The sale if found, null otherwise</returns>
    Task<bool> DeleteAsync(int id);
}
