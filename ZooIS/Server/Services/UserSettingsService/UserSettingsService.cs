// Sukuriama ir istrinama kartu su vartotojo lentele
// ko pasekoje Create ir Delete crud daliu sioje klaseje nera

using Microsoft.EntityFrameworkCore;
using ZooIS.Server.Data;
using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.UserSettingsService
{
    public class UserSettingsService : IUserSettingsService
    {
        private readonly DataContext _context;

        public UserSettingsService(DataContext context)
        {
            _context = context;
        }
        public async Task<UserSettings> GetUserSettings(int id)
        {
            UserSettings? settings = await _context.UserSettings.FirstOrDefaultAsync(s => s.Id == id);
            if (settings != null)
            {
                return settings;
            }
            return null;
        }

        public async Task<UserSettings> UpdateUserSettings(int id, UserSettingsUpdateDto userSettings)
        {
            UserSettings settings = await _context.UserSettings.FirstOrDefaultAsync(s => s.Id == id);
            if(settings == null)
            {
                return null;
            }
            settings.Language = userSettings.Language;
            settings.DarkMode= userSettings.DarkMode;
            await _context.SaveChangesAsync();
            return settings;
        }
    }
}
