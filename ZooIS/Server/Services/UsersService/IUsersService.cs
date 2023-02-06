using ZooIS.Shared;

namespace ZooIS.Server.Services.UsersService
{
    public interface IUsersService
    {
        Task<RegisteredUser> AddRegisteredUser(RegisteredUser user);    //change to DTO
        Task<List<RegisteredUser>> GetAllRegisteredUsers();
        Task<RegisteredUser> GetRegisteredUser(int id);
        Task<RegisteredUser> UpdateRegisteredUser(int id, RegisteredUser user);
        Task DeleteRegisteredUser(int id);
    }
}
