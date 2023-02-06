using ZooIS.Shared;
using ZooIS.Shared.Dto;

namespace ZooIS.Server.Services.UsersService
{
    public interface IUsersService
    {
        Task<RegisteredUser> AddRegisteredUser(UserAddDto userAddDto);    //change to DTO
        Task<List<RegisteredUser>> GetAllRegisteredUsers();
        Task<RegisteredUser> GetRegisteredUser(int id);
        Task<RegisteredUser> UpdateRegisteredUser(int id, UserUpdateInfoDto userUpdadteDto);
        Task<RegisteredUser> DeleteRegisteredUser(int id);
    }
}
