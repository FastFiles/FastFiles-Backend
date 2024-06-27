using Microsoft.AspNetCore.Mvc;
using FastFiles.Models;
using FastFiles.Services;

namespace FastFiles.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            try
            {
                return Ok(_userRepository.GetAll());
            } catch (Exception e)
            {
                return BadRequest($"Error al traer los usuarios: {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetOne(int id)
        {
            var user = _userRepository.GetOne(id);

            if (user == null)
            {
                return NotFound($"No se encontró el usuario con id {id}");
            }
            
            try
            {
                return Ok(user);
            } catch (Exception e)
            {
                return BadRequest($"Error al traer el usuario con id {id}: {e.Message}");
            }
        }
    }
}