using Matrimony.Models.Entities;

namespace Matrimony.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllAsync();

        Task<Country?> GetByIdAsync(int id);

        Task AddAsync(Country country);

        Task UpdateAsync(Country country);

        Task DeleteAsync(Country country);

        Task SaveChangesAsync();
    }
}
