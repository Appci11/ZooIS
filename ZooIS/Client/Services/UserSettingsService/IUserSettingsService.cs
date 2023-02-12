using ZooIS.Shared.Models;

namespace ZooIS.Client.Services.UserSettingsService
{
    public interface IUserSettingsService
    {
        public Task<UserSettings> GetSettings(int id);
        public Task UpdateSettings(UserSettings userSettings);
    }
}
