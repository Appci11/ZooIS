using Microsoft.AspNetCore.Mvc;
using ZooIS.Server.Services.LoginRegisterService;
using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginRegisterController : ControllerBase
    {
        private readonly ILoginRegister _loginRegisterService;

        public LoginRegisterController(ILoginRegister LoginRegisterService)
        {
            _loginRegisterService = LoginRegisterService;
        }

        // Leidziama registruotis su jau anksciau uzregistruotu email'u
        [HttpPost("register")]
        public async Task<ActionResult> Register (UserRegisterDto request)
        {
            RegisteredUser response = await _loginRegisterService.RegisterUser(request);
            if(response != null)
            {
                return Created($"/api/users/{response.Id}", response);
            }
            return NotFound(new { message = "Username already exists" });
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login (UserLoginDto request)
        {
            string token = await _loginRegisterService.LoginUser(request);
            if (token != null)
            {
                //return Ok(new { AuthToken = token });     // kai bus refresh token'as
                return Ok(token);
            }
            else return NotFound(new { message = "Wrong username or password" });
        }
    }
}
