using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.LoginRegisterService
{
    public interface ILoginRegister
    {
        Task<RegisteredUser> RegisterUser(UserRegisterDto request);
        Task<string> LoginUser(UserLoginDto request);
    }
}
