using ZooIS.Shared.Models;

namespace ZooIS.Client.Services.UsersService
{
    public interface IUsersService
    {
        List<RegisteredUser> Users { get; set; }

        Task GetUsers();
        Task<RegisteredUser> GetUser(int id);
        Task CreateUser(RegisteredUser user);
        Task UpdateUser(RegisteredUser user);
        Task DeleteUser(int id);
    }
}
