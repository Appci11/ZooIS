using ZooIS.Shared;
using ZooIS.Shared.Dto;

namespace ZooIS.Server.Services.LoginRegisterService
{
    public interface ILoginRegister
    {
        Task<RegisteredUser> RegisterUser(UserRegisterDto request);
        Task<string> LoginUser(UserLoginDto request);
    }
}
