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
            
#pragma warning disable CS8603 // Possible null reference return.
            return null;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<UserSettings> UpdateUserSettings(int id, UserSettingsUpdateDto userSettings)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            UserSettings settings = await _context.UserSettings.FirstOrDefaultAsync(s => s.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if(settings == null)
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            settings.Language = userSettings.Language;
            settings.DarkMode= userSettings.DarkMode;
            await _context.SaveChangesAsync();
            
            return settings;
        }
    }
}
