using Microsoft.AspNetCore.Mvc;
using FastFiles.Models;
using FastFiles.Services;

namespace FastFiles.Controllers
{
    [ApiController]
    [Route("api/folders/delete")]

    public class FolderDeleteController : ControllerBase
    {
        private readonly IFolderRepository _folderRepository;

        public FolderDeleteController(IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var folderToDelete = _folderRepository.GetOne(id);

                if (folderToDelete == null)
                {
                    return NotFound($"No se encontró la carpeta con id {id}");
                }

                if (folderToDelete.Status != "Inactive")
                {
                    return BadRequest("La carpeta debe estar en la papelera para poder ser eliminada");
                }

                _folderRepository.Delete(folderToDelete);

                return Ok(new { message = "Carpeta eliminada con éxito", folder = folderToDelete });

            } catch (Exception e)
            {
                return BadRequest($"Error al eliminar la carpeta: {e.Message}");
            }
        }
    }
}