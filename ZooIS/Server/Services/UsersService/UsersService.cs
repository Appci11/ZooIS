﻿using Microsoft.EntityFrameworkCore;
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
                return null;
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
            
            return user;
        }

        public async Task<RegisteredUser> UpdateRegisteredUserVVisitor(int id, UpdateUserInfoVisitorDto userUpdateDto)
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
        public async Task<RegisteredUser> UpdateRegisteredUserVAdmin(int id, UpdateUserInfoAdminDto userUpdateDto)
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

        public async Task<int> ChangePassword(UpdatePasswordDto UpdatePasswordDto)
        {
            RegisteredUser dbUser = await _context.RegisteredUsers.FirstOrDefaultAsync(u => u.Username == UpdatePasswordDto.Username);
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
