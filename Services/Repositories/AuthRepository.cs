using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FastFiles.Data;
using FastFiles.Dto;
using Microsoft.IdentityModel.Tokens;

namespace FastFiles.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly FastFilesContext _context;
        private readonly IConfiguration _configuration;
        public AuthRepository(FastFilesContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public string GenerateToken(Authorize user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["key"]);
            var tokenOptions = new JwtSecurityToken(
                issuer: @Environment.GetEnvironmentVariable("Jwturl"),
                audience: @Environment.GetEnvironmentVariable("Jwturl"),
                claims: new List<Claim>(),
                expires: DateTime.Now.AddHours(1),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256)
            );
            return tokenHandler.WriteToken(tokenOptions);
        }
    }
}