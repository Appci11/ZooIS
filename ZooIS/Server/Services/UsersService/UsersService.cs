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
        public async Task<RegisteredUser> AddRegisteredUser(AddRegisteredUserDto userAddDto)
        {
            RegisteredUser registeredUser = new RegisteredUser();

            registeredUser.Username = userAddDto.Username!;
            registeredUser.Email = userAddDto.Email;
            registeredUser.Role = userAddDto.Role;
            registeredUser.RequestPasswordReset = true;
            registeredUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword("aaa");  // Sita slapta "default" slaptazodi i appsettings.json ikelt

            _context.RegisteredUsers.Add(registeredUser);
            await _context.SaveChangesAsync();

            return registeredUser;
        }

        public async Task<RegisteredUser> DeleteRegisteredUser(int id)
        {
            RegisteredUser? user = await _context.RegisteredUsers.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }

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
            
#pragma warning disable CS8603 // Possible null reference return.
            return user;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<RegisteredUser> UpdateRegisteredUserVVisitor(int id, UpdateUserInfoVisitorDto userUpdateDto)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            RegisteredUser dbUser = await _context.RegisteredUsers.FirstOrDefaultAsync(u => u.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (dbUser == null)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
#pragma warning disable CS8601 // Possible null reference assignment.
            dbUser.Username = userUpdateDto.Username;
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
            dbUser.Email = userUpdateDto.Email;
#pragma warning restore CS8601 // Possible null reference assignment.
            await _context.SaveChangesAsync();
           
            return dbUser;
        }
        public async Task<RegisteredUser> UpdateRegisteredUserVAdmin(int id, UpdateUserInfoAdminDto userUpdateDto)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            RegisteredUser dbUser = await _context.RegisteredUsers.FirstOrDefaultAsync(u => u.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (dbUser == null)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
#pragma warning disable CS8601 // Possible null reference assignment.
            dbUser.Username = userUpdateDto.Username;
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
            dbUser.Email = userUpdateDto.Email;
#pragma warning restore CS8601 // Possible null reference assignment.
            dbUser.RequestPasswordReset = userUpdateDto.RequestPasswordReset;
            dbUser.DeletionRequested = userUpdateDto.DeletionRequested;
            dbUser.IsDeleted = userUpdateDto.IsDeleted;
            dbUser.Role = userUpdateDto.Role;

            await _context.SaveChangesAsync();           
            return dbUser;
        }

        public async Task<int> ChangePassword(UpdatePasswordDto UpdatePasswordDto)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            RegisteredUser dbUser = await _context.RegisteredUsers.FirstOrDefaultAsync(u => u.Username == UpdatePasswordDto.Username);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (dbUser == null)
            {
                return 0;
            }
            dbUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(UpdatePasswordDto.Password);
            dbUser.RequestPasswordReset = false;
            dbUser.PassChangeTime = DateTime.Now;
            await _context.SaveChangesAsync();

            return 1;
        }
    }
}
