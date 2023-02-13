using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ZooIS.Server.Data;
using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.LoginRegisterService
{
    public class LoginRegisterService : ILoginRegisterService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public LoginRegisterService(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<RegisteredUser> RegisterUser(UserRegisterDto request)
        {
            RegisteredUser? user = await _context.RegisteredUsers.FirstOrDefaultAsync(u => u.Username == request.Username);
            if (user != null)
            {
                return null;
            }
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user = new RegisteredUser();
            user.Username = request.Username;
            user.Email = request.Email;
            user.PasswordHash = passwordHash;
            _context.RegisteredUsers.Add(user);
            await _context.SaveChangesAsync();
            UserSettings settings = new UserSettings() { Id = user.Id };
            _context.UserSettings.Add(settings);
            await _context.SaveChangesAsync();
            return user;    //per daug grazinu
            //throw new NotImplementedException();
        }

        public async Task<LoginDto> LoginUser(UserLoginDto request)
        {
            RegisteredUser? user = await _context.RegisteredUsers.FirstOrDefaultAsync(u => u.Username == request.Username);
            if (user == null)
            {
                return null;
            }
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return null;
            }
            string token = CreateToken(user);
            return new LoginDto(token, user.RequestPasswordReset);
        }

        public string CreateToken(RegisteredUser user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role),
                // kol tingiu, tol turim ir id
                new Claim("id", user.Id.ToString())
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
