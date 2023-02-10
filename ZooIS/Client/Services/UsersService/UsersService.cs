using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using ZooIS.Shared.Models;

namespace ZooIS.Client.Services.UsersService
{
    public class UsersService : IUsersService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public UsersService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<RegisteredUser> Users { get; set; } = new List<RegisteredUser>();

        public async Task CreateUser(RegisteredUser user)
        {
            var result = await _http.PostAsJsonAsync("/api/users", user);
            _navigationManager.NavigateTo("/users");
        }

        public async Task DeleteUser(int id)
        {
            var result = await _http.DeleteAsync("/api/users/{id}");
            _navigationManager.NavigateTo("/users");
        }

        public async Task<RegisteredUser> GetUser(int id)
        {
            var result = await _http.GetFromJsonAsync<RegisteredUser>("/api/users/{id}");
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
            var result = await _http.PutAsJsonAsync("/api/users/{user.Id}", user);
            _navigationManager.NavigateTo("/users");
        }
    }
}
