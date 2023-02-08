using Microsoft.EntityFrameworkCore;
using ZooIS.Server.Data;
using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.UsersService
{
    public class UsersService : IUsersService
    {
        private readonly DataContext _context;

        public UsersService(DataContext context)
        {
            _context = context;
        }
        public async Task<RegisteredUser> AddRegisteredUser(UserAddDto userAddDto)
        {
            RegisteredUser registeredUser = new RegisteredUser();
            registeredUser.Username = userAddDto.Username!;
            registeredUser.Email = userAddDto.Email;
            registeredUser.Role = userAddDto.Role;
            registeredUser.RequestPasswordReset = true;

            _context.RegisteredUsers.Add(registeredUser);
            await _context.SaveChangesAsync();
            UserSettings settings = new UserSettings() { Id = registeredUser.Id };
            _context.UserSettings.Add(settings);
            await _context.SaveChangesAsync();
            return registeredUser;
        }

        public async Task<RegisteredUser> DeleteRegisteredUser(int id)
        {
            RegisteredUser? user = await _context.RegisteredUsers.FirstOrDefaultAsync(u => u.Id == id);
            UserSettings? settings = await _context.UserSettings.FirstOrDefaultAsync(s => s.Id == id);

            if (user == null || settings == null)
            {
                return null;
            }
            _context.UserSettings.Remove(settings);
            _context.RegisteredUsers.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<RegisteredUser>> GetAllRegisteredUsers()
        {
            return await _context.RegisteredUsers.ToListAsync();
        }

        public async Task<RegisteredUser> GetRegisteredUser(int id)
        {
            RegisteredUser? user = await _context.RegisteredUsers.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<RegisteredUser> UpdateRegisteredUserVVisitor(int id, UserUpdateInfoVisitorDto userUpdateDto)
        {
            RegisteredUser dbUser = await _context.RegisteredUsers.FirstOrDefaultAsync(u => u.Id == id);
            if (dbUser == null)
            {
                return null;
            }
            dbUser.Username = userUpdateDto.Username;
            dbUser.Email = userUpdateDto.Email;
            await _context.SaveChangesAsync();
            return dbUser;
        }
        public async Task<RegisteredUser> UpdateRegisteredUserVAdmin(int id, UserUpdateInfoAdminDto userUpdateDto)
        {
            RegisteredUser dbUser = await _context.RegisteredUsers.FirstOrDefaultAsync(u => u.Id == id);
            if (dbUser == null)
            {
                return null;
            }
            dbUser.Username = userUpdateDto.Username;
            dbUser.Email = userUpdateDto.Email;
            dbUser.RequestPasswordReset = userUpdateDto.RequestPasswordReset;
            dbUser.DeletionRequested = userUpdateDto.DeletionRequested;
            dbUser.IsDeleted = userUpdateDto.IsDeleted;
            dbUser.Role = userUpdateDto.Role;
            await _context.SaveChangesAsync();
            return dbUser;
        }
    }
}
