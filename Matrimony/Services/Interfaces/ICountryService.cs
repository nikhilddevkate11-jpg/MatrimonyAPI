using Matrimony.API.Common;
using Matrimony.Models.DTOs.Country;

namespace Matrimony.Services.Interfaces
{
    public interface ICountryService
    {
        Task<ApiResponse<List<CountryDto>>> GetAllAsync();

        Task<ApiResponse<CountryDto>> GetByIdAsync(int id);

        Task<ApiResponse<object>> CreateAsync(CreateCountryDto dto);

        Task<ApiResponse<object>> UpdateAsync(int id, UpdateCountryDto dto);

        Task<ApiResponse<object>> DeleteAsync(int id);
    }
}
