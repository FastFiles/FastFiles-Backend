using Microsoft.AspNetCore.Mvc;
using FastFiles.Models;
using FastFiles.Services;

namespace FastFiles.Controllers
{
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

                if (folder == null)
                {
                    return NotFound($"No se encontró la carpeta con id {id}");
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