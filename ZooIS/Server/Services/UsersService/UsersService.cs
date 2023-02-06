using ZooIS.Server.Data;
using ZooIS.Shared;

namespace ZooIS.Server.Services.UsersService
{
    public class UsersService : IUsersService
    {
        private readonly DataContext _context;

        public UsersService(DataContext context)
        {
            _context = context;
        }
        public async Task<RegisteredUser> AddRegisteredUser(RegisteredUser registeredUser)
        {
            _context.RegisteredUsers.Add(registeredUser);
            await _context.SaveChangesAsync();
            return registeredUser;
            //throw new NotImplementedException();
        }

        public Task DeleteRegisteredUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<RegisteredUser>> GetAllRegisteredUsers()
        {
            throw new NotImplementedException();
        }

        public Task<RegisteredUser> GetRegisteredUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RegisteredUser> UpdateRegisteredUser(int id, RegisteredUser user)
        {
            throw new NotImplementedException();
        }
    }
}
