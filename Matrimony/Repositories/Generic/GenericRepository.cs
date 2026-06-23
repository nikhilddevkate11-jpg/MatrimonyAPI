using Matrimony.API.Data;
using Matrimony.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Matrimony.Repositories.Generic
{
    public class GenericRepository<T> : IGenericRepository<T>
    where T : BaseEntity
    {
        protected readonly ApplicationDbContext _context;

        protected readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet
                .Where(x => x.IsActive)
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
        }

        public async Task AddAsync(T entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            entity.IsActive = true;
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            _dbSet.Update(entity);
        }

        public async Task SoftDeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null)
                return;

            entity.IsActive = false;
            entity.DeletedDate = DateTime.UtcNow;

            _dbSet.Update(entity);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _dbSet.AnyAsync(x => x.Id == id && x.IsActive);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
