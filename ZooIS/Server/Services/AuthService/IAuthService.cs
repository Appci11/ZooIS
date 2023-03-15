using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.AuthService
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterUser(RegisterUserDto request);
        Task<AuthResponseDto> LoginUser(AuthUserDto request);
    }
}
