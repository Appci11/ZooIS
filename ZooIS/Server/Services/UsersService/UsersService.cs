﻿using Microsoft.EntityFrameworkCore;
using ZooIS.Server.Data;
using ZooIS.Shared;
using ZooIS.Shared.Dto;

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
            registeredUser.Username= userAddDto.Username;
            registeredUser.Email = userAddDto.Email;
            registeredUser.Role = userAddDto.Role;
            registeredUser.RequestPasswordReset = true;
            _context.RegisteredUsers.Add(registeredUser);
            await _context.SaveChangesAsync();
            return registeredUser;
        }

        public async Task<RegisteredUser> DeleteRegisteredUser(int id)
        {
            RegisteredUser? user = await _context.RegisteredUsers.FirstOrDefaultAsync(u => u.Id == id);
            if(user == null)
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

        public async Task<RegisteredUser> UpdateRegisteredUser(int id, UserUpdateInfoDto userUpdateDto)
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
    }
}