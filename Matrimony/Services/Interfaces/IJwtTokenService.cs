using Matrimony.API.Models.Entities;

namespace Matrimony.Services.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }
}
