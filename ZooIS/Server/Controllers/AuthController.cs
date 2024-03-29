﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using ZooIS.Server.Services.AuthService;
using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _loginRegisterService;

        public AuthController(IAuthService LoginRegisterService)
        {
            _loginRegisterService = LoginRegisterService;
        }

        // Leidziama registruotis su jau anksciau uzregistruotu email'u
        [HttpPost("register")]
        public async Task<ActionResult> Register (RegisterUserDto request)
        {
            AuthResponseDto response = await _loginRegisterService.RegisterUser(request);
            if (response != null)
            {
                return Created($"/api/users/{response.UserId}", response);
            }
            return NotFound(new { message = "Username already exists" });
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login (AuthUserDto request)
        {
            AuthResponseDto response = await _loginRegisterService.LoginUser(request);
            if (response != null)
            {
                return Ok(response);
            }
            else return NotFound(new { message = "Wrong username or password" });
        }

        //pasitikrinimui ar veikia
        [HttpGet("userIsVisitorMsg")]
        [Authorize(Roles = "Visitor")]
        public ActionResult<string> GetMessageRegisteredUser()
        {
            //var userName = _userService.GetMyName();
            return Ok("Registered users can read this");
        }
        [HttpGet("userIsSysAdminMsg")]
        [Authorize(Roles = "SysAdmin")]
        public ActionResult<string> GetMessageAdmin()
        {
            return Ok("SysAdmins can read this");
        }
    }
}
