using Microsoft.AspNetCore.Mvc;
using FastFiles.Models;
using FastFiles.Services;

namespace FastFiles.Controllers
{
    [ApiController]
    [Route("api/folders")]

    public class FolderUpdateController : ControllerBase
    {
        private readonly IFolderRepository _folderRepository;

        public FolderUpdateController(IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }

        [HttpPost("{id}")]
        public IActionResult Update(int id, Folder folder)
        {
            try
            {
                var folderToUpdate = _folderRepository.GetOne(id);

                if (folderToUpdate == null)
                {
                    return NotFound($"No se encontró la carpeta con id {id}");
                }

                folderToUpdate.Name = folder.Name;
                folderToUpdate.Description = folder.Description;
                folderToUpdate.Location = folder.Location;

                _folderRepository.Update(folderToUpdate);

                return Ok(new { message = "Carpeta actualizada con éxito", folder = folderToUpdate });
            } catch (Exception e)
            {
                return BadRequest($"Error al actualizar la carpeta: {e.Message}");
            }
        }
    }
}