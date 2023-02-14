using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using ZooIS.Shared.Models;

namespace ZooIS.Client.Services.UsersService
{
    public class UsersService : IUsersService
    {
        private readonly HttpClient _http;

        public UsersService(HttpClient http)
        {
            _http = http;
        }
        public List<RegisteredUser> Users { get; set; } = new List<RegisteredUser>();

        public async Task CreateUser(RegisteredUser user)
        {
            var result = await _http.PostAsJsonAsync($"/api/users", user);
        }

        public async Task DeleteUser(int id)
        {
            var result = await _http.DeleteAsync($"/api/users/{id}");
            RegisteredUser user = Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                Users.Remove(user);
            }
        }

        public async Task<RegisteredUser> GetUser(int id)
        {
            var result = await _http.GetFromJsonAsync<RegisteredUser>($"/api/users/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("User not found");
        }

        public async Task GetUsers()
        {
            var result = await _http.GetFromJsonAsync<List<RegisteredUser>>("/api/users");
            if (result != null)
            {
                Users = result;
            }
        }

        public async Task UpdateUser(RegisteredUser user)
        {
            var result = await _http.PutAsJsonAsync($"/api/users/{user.Id}", user);

        }
    }
}
