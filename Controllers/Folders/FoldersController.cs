using Microsoft.AspNetCore.Mvc;
using FastFiles.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims; 
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace FastFiles.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] 
    [ApiController]
    [Route("api/folders")]
    public class FoldersController : ControllerBase
    {
        
        private readonly IFolderRepository _folderRepository;


        public FoldersController(IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }

        [HttpGet]
        public IActionResult GetFolders()
        {
            try
            {
                return Ok(_folderRepository.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest($"Error al traer las carpetas: {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetFolder(int id)
        {
            try
            {
                var folder = _folderRepository.GetOne(id);

                var userId = int.Parse(User.FindFirst("id").Value);
                var UserIdClaim = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;  //Obtenemos le id del usuario
                

                if (folder == null || UserIdClaim == null ) //Ponemos el operador O para que sea una cosa o la otra(Antes tenia un &&)
                {
                    return NotFound($"No se encontró la carpeta con id {id}");
                }
                if(folder.UserId != userId)
                {
                    return Unauthorized("No tienes permisos para mirar esta carpeta");
                }

                return Ok(folder);
            }
            catch (Exception e)
            {
                return BadRequest($"Error al traer la carpeta: {e.Message}");
            }
        }
    }
}