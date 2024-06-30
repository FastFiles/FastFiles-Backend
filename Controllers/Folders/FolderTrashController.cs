using Microsoft.AspNetCore.Mvc;
using FastFiles.Models;
using FastFiles.Services;

namespace FastFiles.Controllers
{
    [ApiController]
    [Route("api/folders/trash")]

    public class FolderTrashController : ControllerBase
    {
        private readonly IFolderRepository _folderRepository;

        public FolderTrashController(IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }

        [HttpPost("{id}")]
        public IActionResult Trash(int id)
        {
            try
            {
                var folderToTrash = _folderRepository.GetOne(id);

                if (folderToTrash == null)
                {
                    return NotFound($"No se encontró la carpeta con id {id}");
                }

                _folderRepository.Trash(folderToTrash);

                return Ok(new { message = "Carpeta enviada a la papelera con éxito", folder = folderToTrash });
            } catch (Exception e)
            {
                return BadRequest($"Error al enviar la carpeta a la papelera: {e.Message}");
            }
        }
    }
}