using AutoMapper;
using Matrimony.API.Common;
using Matrimony.Models.DTOs.Country;
using Matrimony.Models.Entities;
using Matrimony.Repositories.Interfaces;
using Matrimony.Services.Interfaces;

namespace Matrimony.Services.Implementations
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _repository;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository repository,
                              IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<CountryDto>>> GetAllAsync()
        {
            var countries = await _repository.GetAllAsync();

            var result = _mapper.Map<List<CountryDto>>(countries);

            return new ApiResponse<List<CountryDto>>(
                true,
                "Countries fetched successfully.",
                result);
        }

        public async Task<ApiResponse<CountryDto>> GetByIdAsync(int id)
        {
            var country = await _repository.GetByIdAsync(id);

            if (country == null)
                return new ApiResponse<CountryDto>(
                    false,
                    "Country not found.");

            return new ApiResponse<CountryDto>(
                true,
                "Country fetched successfully.",
                _mapper.Map<CountryDto>(country));
        }

        public async Task<ApiResponse<object>> CreateAsync(CreateCountryDto dto)
        {
            var country = _mapper.Map<Country>(dto);

            country.IsActive = true;
            country.CreatedDate = DateTime.UtcNow;

            await _repository.AddAsync(country);
            await _repository.SaveChangesAsync();

            return new ApiResponse<object>(
                true,
                "Country created successfully.");
        }

        public async Task<ApiResponse<object>> UpdateAsync(int id, UpdateCountryDto dto)
        {
            var country = await _repository.GetByIdAsync(id);

            if (country == null)
                return new ApiResponse<object>(
                    false,
                    "Country not found.");

            _mapper.Map(dto, country);

            await _repository.UpdateAsync(country);
            await _repository.SaveChangesAsync();

            return new ApiResponse<object>(
                true,
                "Country updated successfully.");
        }

        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            var country = await _repository.GetByIdAsync(id);

            if (country == null)
                return new ApiResponse<object>(
                    false,
                    "Country not found.");

            await _repository.DeleteAsync(country);
            await _repository.SaveChangesAsync();

            return new ApiResponse<object>(
                true,
                "Country deleted successfully.");
        }
    }
}
