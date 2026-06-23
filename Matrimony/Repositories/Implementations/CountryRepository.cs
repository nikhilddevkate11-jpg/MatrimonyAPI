using Matrimony.API.Data;
using Matrimony.Models.Entities;
using Matrimony.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Matrimony.Repositories.Implementations
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Country>> GetAllAsync()
        {
            return await _context.Countries
                .Where(c => c.IsActive)
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<Country?> GetByIdAsync(int id)
        {
            return await _context.Countries.FindAsync(id);
        }

        public async Task AddAsync(Country country)
        {
            await _context.Countries.AddAsync(country);
        }

        public Task UpdateAsync(Country country)
        {
            _context.Countries.Update(country);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Country country)
        {
            //_context.Countries.Remove(country);
            country.IsActive = false;
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
