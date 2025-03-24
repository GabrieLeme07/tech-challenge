using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class RatingRepository : IRatingRepository
{
    public Task<Rating> CreateAsync(Rating entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Rating>> GetAllAsync(int take, int skip)
    {
        throw new NotImplementedException();
    }

    public Task<Rating> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdatedAsync(Rating entity)
    {
        throw new NotImplementedException();
    }
}
