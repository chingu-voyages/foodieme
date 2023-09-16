using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Interfaces;

namespace webapi.Services
{
    public class GenericServices<T> : IGenericService<T> where T : class
    {
        private readonly ApplicationDbContext context;

        public GenericServices(ApplicationDbContext _context)
        {
            this.context = _context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task AddRangeAsync(List<T> entities)
        {
            await context.AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity == null) return false;
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            return entity != null;

        }

        public async Task<List<T>> GetAllAsync()
        {
            var list = await context.Set<T>().ToListAsync();
            return list;
        }

        public async Task<T?> GetAsync(int? id)
        {
            if (id == null) return null;
            return await context.Set<T>().FindAsync(id);
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
