using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZooIS.Server.Services.UsersService;
using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _registeredUsersService;

        public UsersController(IUsersService registeredUsersService)
        {
            _registeredUsersService = registeredUsersService;
        }

        [HttpPost]
        public async Task<IActionResult> AddRegisteredUser(AddRegisteredUserDto userAddDto)
        {
            RegisteredUser response = await _registeredUsersService.AddRegisteredUser(userAddDto);
            if (response != null)
            {
                return Created($"/api/users/{response.Id}", response);
            }
            else return NotFound(new { message = "User not created" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            List<RegisteredUser> response = await _registeredUsersService.GetAllRegisteredUsers();
            if (response.Count > 0)
            {
                return Ok(response);
            }
            return NotFound(new { message = "No Users Found" });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RegisteredUser>> GetUser(int id)
        {
            RegisteredUser response = await _registeredUsersService.GetRegisteredUser(id);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound(new { message = "User not found" });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RegisteredUser>> UpdateUser(int id, UserUpdateInfoAdminDto userUpdateDto)
        {
            RegisteredUser response = await _registeredUsersService.UpdateRegisteredUserVAdmin(id, userUpdateDto);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound(new { message = "User not found" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            RegisteredUser response = await _registeredUsersService.DeleteRegisteredUser(id);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound(new { message = "User not found" });
        }

        [HttpPatch("passchange")]
        public async Task<IActionResult> ChangePassword(PasswordChangeDto passChangeDto)
        {
            int response = await _registeredUsersService.ChangePassword(passChangeDto);
            if(response != 0)
            {
                return Ok(new { message = "Password change successfull." });
            }
            return BadRequest(new { message = "User not found" });
        }
    }
}
