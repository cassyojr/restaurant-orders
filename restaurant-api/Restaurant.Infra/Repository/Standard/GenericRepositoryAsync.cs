using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Repository.Standard;
using Restaurant.Infra.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.Infra.Repository.Standard
{
    public class GenericRepositoryAsync<TEntity> : IGenericRepositoryAsync<TEntity> where TEntity : class
    {
        protected readonly ApplicationContext _context;

        public GenericRepositoryAsync(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<TEntity> AddAsync(TEntity obj)
        {
            var entryEntity = await _context.Set<TEntity>().AddAsync(obj);

            await _context.SaveChangesAsync();

            return entryEntity.Entity;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task RemoveAsync(object id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null) return;

            _context.Set<TEntity>().Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return obj;
        }
    }
}
