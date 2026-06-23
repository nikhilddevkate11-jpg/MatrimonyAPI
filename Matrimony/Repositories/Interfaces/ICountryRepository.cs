using Matrimony.Models.Entities;
using Matrimony.Repositories.Generic;

namespace Matrimony.Repositories.Interfaces
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Task<bool> ExistsByNameAsync(string name);

        Task<List<Country>> SearchAsync(string keyword);
    }
}
