using System.Net.Http.Json;
using ZooIS.Shared.Models;

namespace ZooIS.Client.Services.UserSettingsService
{
    public class UserSettingsService : IUserSettingsService
    {
        private readonly HttpClient _httpClient;

        public UserSettingsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<UserSettings> GetSettings(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<UserSettings>($"/api/usersettings/{id}");
            if (result != null)
            {
                return result;
            }
#pragma warning disable CS8603 // Possible null reference return.
            return null;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public Task UpdateSettings(UserSettings userSettings)
        {
            throw new NotImplementedException();
        }
    }
}
