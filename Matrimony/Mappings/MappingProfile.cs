using AutoMapper;
using Matrimony.API.Models.Entities;
using Matrimony.Models.DTOs;
using Matrimony.Models.DTOs.Country;
using Matrimony.Models.Entities;

namespace Matrimony.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User
            CreateMap<User, UserDto>();
            CreateMap<RegisterUserDto, User>();

            // Country
            CreateMap<Country, CountryDto>();
            CreateMap<CreateCountryDto, Country>();
            CreateMap<UpdateCountryDto, Country>();
        }
    }
}
