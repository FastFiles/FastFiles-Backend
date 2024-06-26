using Microsoft.AspNetCore.Mvc;
using FastFiles.Models;
using FastFiles.Services;

namespace FastFiles.Controllers
{
    [ApiController]
    [Route("api/users")]

    public class UserCreateController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserCreateController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            try
            {
                _userRepository.Create(user);
                
                return Ok(new { message =  "Usuario creado con éxito", user });
            } catch (Exception e)
            {
                return BadRequest($"Error al crear nuevo usuario: {e.Message}");
            }
        }
    }
}