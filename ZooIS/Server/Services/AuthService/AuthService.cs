using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ZooIS.Shared.Dto;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        const string REFRESH_TOKEN = "TOTALLY_LEGIT-refresh-token"; //Sutvarkyt + data saugot pakeitimui

        public AuthService(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<AuthResponseDto> RegisterUser(RegisterUserDto request)
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
            user.PassChangeTime = DateTime.Now;
            _context.RegisteredUsers.Add(user);
            await _context.SaveChangesAsync();
            UserSettings settings = new UserSettings() { Id = user.Id };
            _context.UserSettings.Add(settings);
            await _context.SaveChangesAsync();
            AuthResponseDto response = new AuthResponseDto();
            response.Username = request.Username;
            if (request.returnSecureToken)
                response.IdToken = CreateToken(user);
            response.RefreshToken = REFRESH_TOKEN;
            response.ExpiresIn = DateTime.Now.AddHours(24);
            response.PassResetRequest = user.RequestPasswordReset;
            response.UserId = user.Id;
            return response;

            //throw new NotImplementedException();
        }

        public async Task<AuthResponseDto> LoginUser(AuthUserDto request)
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
            string idToken = CreateToken(user);
            return new AuthResponseDto
            {
                Username = user.Username,
                IdToken = idToken,
                ExpiresIn = DateTime.Now.AddHours(24),
                RefreshToken = REFRESH_TOKEN,
                UserId = user.Id,
                PassResetRequest = user.RequestPasswordReset
            };
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
                expires: DateTime.Now.AddHours(24), //kol refresh tokeno nera,  tol 24h
                signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
