using Microsoft.AspNetCore.Mvc;
using FastFiles.Models;
using FastFiles.Services;

namespace FastFiles.Controllers
{
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
                if (folder == null)
                {
                    return BadRequest($"La carpeta tiene datos nulos");
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