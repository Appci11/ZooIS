using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Client.Services.UsersService
{
    public interface IUsersService
    {
        List<RegisteredUser> Users { get; set; }

        Task GetUsers();
        Task<RegisteredUser> GetUser(int id);
        Task<bool> CreateUser(RegisteredUser user);
        Task<bool> UpdateUser(RegisteredUser user);
        Task<bool> DeleteUser(int id);
        Task<bool> UpdatePassword(UpdatePasswordDto updatePasswordDto);
    }
}
