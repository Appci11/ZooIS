using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.LoginRegisterService
{
    public interface ILoginRegisterService
    {
        Task<RegisteredUser> RegisterUser(UserRegisterDto request);
        Task<string> LoginUser(UserLoginDto request);
    }
}
