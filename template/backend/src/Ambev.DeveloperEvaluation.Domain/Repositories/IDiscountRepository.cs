using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for Discount entity operations
/// </summary>
public interface IDiscountRepository
{
    /// <summary>
    /// Creates a new Discount in the repository
    /// </summary>
    /// <param name="entity">The Discount to create</param>
    Task<Discount> CreateAsync(Discount entity);

    /// <summary>
    /// Retrieves a Discount by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the Discount</param>
    /// <returns>The Discount if found, null otherwise</returns>
    Task<Discount> GetByIdAsync(int id);

    /// <summary>
    /// Retrieves all Discount
    /// </summary>
    Task<IEnumerable<Discount>> GetAllAsync();
}
