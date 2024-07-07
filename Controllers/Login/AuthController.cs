using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FastFiles.Data;
using FastFiles.Dto;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FastFiles.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AuthController : ControllerBase
    {
        private readonly FastFilesContext _context;
        public AuthController (FastFilesContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task <IActionResult> login ([FromBody] Authorize User)  //Usamos el Uthorize de los Dto
        { 
            //Hacemos la validación con la base de datos
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == User.Email && u.Password == User.Password);
            if (user == null)
            {
                return Unauthorized("Hubo un problema en la contraseña o en el correo");
            }
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mcrfnief3ie84r4hrffrñ@dnrcnjfcnfnjcnjr232N"));
            var singningCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            //Usamos el claims para las reclamaciones del token 
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim("id",user.Id.ToString()) //Agregams este para la validación entre los users
            };

            //Agregamos las opciones del token 
            var tokenOptions = new JwtSecurityToken(
                issuer: @Environment.GetEnvironmentVariable("Jwturl"),
                audience: @Environment.GetEnvironmentVariable("Jwturl"),
                claims: claims, //Aqui usmos los claims para validaciones
                expires: DateTime.Now.AddHours(1),
                signingCredentials: singningCredentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok (new {Token = token});
        }
    }
}