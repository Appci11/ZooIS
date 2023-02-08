using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZooIS.Server.Services.UserSettingsService;
using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSettingsController : ControllerBase
    {
        private readonly IUserSettingsService _userSettingsService;

        public UserSettingsController(IUserSettingsService userSettingsService)
        {
            _userSettingsService = userSettingsService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserSettings>> GetUserSettings(int id)
        {
            UserSettings response = await _userSettingsService.GetUserSettings(id);
            if(response != null)
            {
                return Ok(response);
            }
            return NotFound(new {message = "User settings not found"});
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UserSettings>> UpdateUserSettings(int id, UserSettingsUpdateDto settingsUpdateDto)
        {
            UserSettings response = await _userSettingsService.UpdateUserSettings(id, settingsUpdateDto);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound(new { message = "User settings not found" });
        }

    }
}
