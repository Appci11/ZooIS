using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZooIS.Server.Services.UsersService;
using ZooIS.Shared;

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
        public async Task<IActionResult> AddRegisteredUser (RegisteredUser registeredUser)
        {
            RegisteredUser response = await _registeredUsersService.AddRegisteredUser(registeredUser);
            if(response != null)
            {
                return Created($"/api/users/{response.Id}", response);
            }
            else return NotFound(new {message = "User not created"});
        }
    }
}
