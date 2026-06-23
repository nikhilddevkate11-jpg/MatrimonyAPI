using Matrimony.Models.DTOs;
using Matrimony.API.Common;

namespace Matrimony.Services.Interfaces
{
    public interface IUserService
    {
        Task<ApiResponse<object>> RegisterAsync(RegisterUserDto dto);

        Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginDto dto);
    }
}
