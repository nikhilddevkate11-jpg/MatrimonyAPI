using Matrimony.API.Data;
using Matrimony.Models.Entities;
using Matrimony.Repositories.Generic;
using Matrimony.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Matrimony.Repositories.Implementations
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context) : base(context)        {
            
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Countries
                .AnyAsync(x => x.Name.ToLower() == name.ToLower()
                            && x.IsActive);
        }

        public async Task<List<Country>> SearchAsync(string keyword)
        {
            return await _context.Countries
                .Where(x => x.IsActive &&
                            x.Name.Contains(keyword))
                .OrderBy(x => x.Name)
                .ToListAsync();
        }
    }
}
