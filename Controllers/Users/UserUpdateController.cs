using Microsoft.AspNetCore.Mvc;
using FastFiles.Models;
using FastFiles.Services;

namespace FastFiles.Controllers
{
    [ApiController]
    [Route("api/users/update")]

    public class UserUpdateController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserUpdateController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("{id}")]
        public IActionResult UpdateUser(User user)
        {
            try
            {
                _userRepository.Update(user);

                return Ok(new { message =  "Usuario actualizado con éxito", user });
            } catch (Exception e)
            {
                return BadRequest($"Error al actualizar usuario: {e.Message}");
            }
        }
    }
}