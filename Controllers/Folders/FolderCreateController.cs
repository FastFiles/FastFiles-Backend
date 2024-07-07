using Microsoft.AspNetCore.Mvc;
using FastFiles.Models;
using FastFiles.Services;
using Microsoft.AspNetCore.Authorization;
using  System.Security.Claims;

namespace FastFiles.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/folders")]

    public class FolderCreateController : ControllerBase
    {
        private readonly IFolderRepository _folderRepository;

        public FolderCreateController(IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }

        [HttpPost]
        public IActionResult CreateFolder(Folder folder)
        {
            try
            {
                var UserIdClaim = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var userId = int.Parse(User.FindFirst("id").Value);

                if (folder == null)
                {
                    return BadRequest($"La carpeta tiene datos nulos");
                }
                if(UserIdClaim == null)
                {
                    return Unauthorized("No tiene permisos para crear carpetas");
                }
                if (folder.UserId == userId)
                {
                    return Ok("La carpeta se a creado con exito");
                }
                _folderRepository.Create(folder);
                return Ok(folder);   
            }
            catch (Exception e)
            {
                return BadRequest($"Error al crear la carpeta: {e.Message}");
            }
        }
    }
}