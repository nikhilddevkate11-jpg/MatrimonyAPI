using Matrimony.Models.Entities;

namespace Matrimony.Repositories.Generic
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();

        Task<T?> GetByIdAsync(int id);

        Task AddAsync(T entity);

        void Update(T entity);

        Task SoftDeleteAsync(int id);

        Task<bool> ExistsAsync(int id);

        Task SaveChangesAsync();
    }
}
