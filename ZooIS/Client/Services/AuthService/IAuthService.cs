using ZooIS.Shared.Dto;

namespace ZooIS.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<bool> Register(RegisterUserDto registerUserDto);
        Task<int> Login(AuthUserDto authUserDto, bool stayLoggedIn);
        Task<bool> Logout();
        Task<bool> RefreshTokens();
    }
}
