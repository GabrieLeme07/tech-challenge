using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.UOW;

/// <summary>
/// Unit Of Work Pattern
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly DefaultContext _context;

    public UnitOfWork(DefaultContext context)
        => _context = context;

    /// <summary>
    /// Save all changes to the database
    /// </summary>
    public async Task<bool> Commit()
        => await _context.SaveChangesAsync() > 0;

    public void Dispose()
        => _context.Dispose();
}
