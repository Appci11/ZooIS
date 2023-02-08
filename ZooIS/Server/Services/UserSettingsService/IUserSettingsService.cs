using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.UserSettingsService
{
    public interface IUserSettingsService
    {
        Task<UserSettings> GetUserSettings(int id);
        Task<UserSettings> UpdateUserSettings(int id, UserSettingsUpdateDto userSettings);

        // tikraiusiai nereikes, bus pasalinta automatiskai kai userAcc bus salinamas
        //Task DeleteUserSettings(int id);
    }
}
