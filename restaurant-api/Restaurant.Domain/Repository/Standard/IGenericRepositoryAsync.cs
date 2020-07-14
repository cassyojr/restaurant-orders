using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.Domain.Repository.Standard
{
    public interface IGenericRepositoryAsync<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(object id);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> AddAsync(TEntity obj);
        Task<TEntity> UpdateAsync(TEntity obj);
        Task RemoveAsync(object id);
    }
}
