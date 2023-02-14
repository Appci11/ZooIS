using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.UsersService
{
    public interface IUsersService
    {
        Task<RegisteredUser> AddRegisteredUser(AddRegisteredUserDto userAddDto);
        Task<List<RegisteredUser>> GetAllRegisteredUsers();
        Task<RegisteredUser> GetRegisteredUser(int id);
        Task<RegisteredUser> UpdateRegisteredUserVVisitor(int id, UserUpdateInfoVisitorDto userUpdadteDto);
        Task<RegisteredUser> UpdateRegisteredUserVAdmin(int id, UserUpdateInfoAdminDto userUpdadteDto);
        Task<RegisteredUser> DeleteRegisteredUser(int id);
        Task<int> ChangePassword(PasswordChangeDto passwordChangeDto);
    }
}
