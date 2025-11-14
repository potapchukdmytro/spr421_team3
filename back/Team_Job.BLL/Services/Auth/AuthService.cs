using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Team_Job.BLL.Dtos.Auth;
using Team_Job.BLL.Settings;
using Team_Job.DAL.Entities.Identity;
using Team_Job.DAL.Settings;

namespace Team_Job.BLL.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtSettings _jwtSettings;

        public AuthService(UserManager<ApplicationUser> userManager, IOptions<JwtSettings> jwtOptions)
        {
            _userManager = userManager;
            _jwtSettings = jwtOptions.Value;
        }

        public async Task<ServiceResponse> LoginAsync(LoginDto dto)
        {
            var user = await GetByLoginAsync(dto.Login);

            if (user == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Логін вказано невірно"
                };
            }

            bool passwordResult = await _userManager.CheckPasswordAsync(user, dto.Password);

            if (!passwordResult)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Пароль вказано невірно"
                };
            }

            string token = await GenerateJwtTokenAsync(user);

            return new ServiceResponse
            {
                Message = "Успішний вхід",
                Payload = token
            };
        }

        private async Task<ApplicationUser?> GetByLoginAsync(string login)
        {
            return await _userManager.Users
                .FirstOrDefaultAsync(u => u.NormalizedEmail == login.ToUpper()
                || u.NormalizedUserName == login.ToUpper());
        }

        private async Task<string> GenerateJwtTokenAsync(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim("id", user.Id!),
                new Claim("userName", user.UserName!),
                new Claim("email", user.Email!),
                new Claim("firstName", user.FirstName ?? string.Empty),
                new Claim("lastName", user.LastName ?? string.Empty),
                new Claim("avatar", user.AvatarUrl ?? string.Empty)
            };

            var userRoles = await _userManager.GetRolesAsync(user);

            if (userRoles.Count == 0)
            {
                userRoles.Add(RoleSettings.RoleUser);
            }

            var roleClaims = userRoles.Select(r => new Claim("roles", r));
            claims.AddRange(roleClaims);

            var secretKey = _jwtSettings.SecretKey;

            if (string.IsNullOrEmpty(secretKey))
            {
                throw new ArgumentNullException(nameof(secretKey));
            }

            var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                audience: _jwtSettings.Audience,
                issuer: _jwtSettings.Issuer,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(_jwtSettings.ExpireHours),
                signingCredentials: credentials
                );

            var handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }

        public async Task<ServiceResponse> RegisterAsync(RegisterDto dto)
        {
            if (dto == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Помилка"
                };
            }

            var user = new ApplicationUser
            {
                Email = dto.Email,
                UserName = dto.Login,
                EmailConfirmed = true,
                FirstName = dto.FisrtName,
                LastName = dto.LastName
            };

            if (_userManager.Users.Contains(user))
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Вже є такий акаунт"
                };
            }
            await _userManager.CreateAsync(user, dto.Password);

            await _userManager.AddToRoleAsync(user, dto.Role);

            return new ServiceResponse
            {
                Message = "Успішна реєстрація"
            };
        }
    }
}
