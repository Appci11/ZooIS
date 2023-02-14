using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.UserSettingsService
{
    public interface IUserSettingsService
    {
        // creates on RegisteredUser creation
        // deletes on RegisteredUser deletion (cascading option in database)
        Task<UserSettings> GetUserSettings(int id);
        Task<UserSettings> UpdateUserSettings(int id, UserSettingsUpdateDto userSettings);
    }
}
