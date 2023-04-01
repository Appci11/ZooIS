using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Client.Services.UsersService
{
    // Sutvarkyt
    // ankstyvas, "naivus" variantas, turint laiko daugia patikrinimu idet, pagrinde respopnse patikrint
    public class UsersService : IUsersService
    {
        private readonly HttpClient _http;

        public UsersService(HttpClient http)
        {
            _http = http;
        }
        public List<RegisteredUser> Users { get; set; } = new List<RegisteredUser>();

        public async Task<bool> CreateUser(RegisteredUser user)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync($"/api/users", user);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var response = await _http.DeleteAsync($"/api/users/{id}");
            if (response.IsSuccessStatusCode)
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                RegisteredUser user = Users.FirstOrDefault(u => u.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                if (user != null)
                {
                    Users.Remove(user);
                    return true;
                }
            }
            return false;
        }

        public async Task<RegisteredUser> GetUser(int id)
        {
            var result = await _http.GetFromJsonAsync<RegisteredUser>($"/api/users/{id}");
            if (result != null)
            {
                return result;
            }
#pragma warning disable CS8603 // Possible null reference return.
            return null;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task GetUsers()
        {
            List<RegisteredUser> result = new List<RegisteredUser>();
            try
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                result = await _http.GetFromJsonAsync<List<RegisteredUser>>("/api/users");
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            }
            catch { }
            if (result != null && result.Count > 0)
            {
                Users = result;
            }
            // else, pagal plana, matys tuscia sarasa
        }

        public async Task<bool> UpdateUser(RegisteredUser user)
        {
            HttpResponseMessage response = await _http.PutAsJsonAsync($"/api/users/{user.Id}", user);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdatePassword(UpdatePasswordDto dto)
        {
            HttpResponseMessage result = await _http.PatchAsJsonAsync("/api/users/passchange", dto);
            return result.IsSuccessStatusCode;
        }
    }
}
