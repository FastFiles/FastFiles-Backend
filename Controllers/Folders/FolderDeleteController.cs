using Microsoft.AspNetCore.Mvc;
using FastFiles.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;

namespace FastFiles.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] //Aqui validamos con el token Jwt
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
            //Agregamos las variables para luego hacer las validaciones
            try
            {
                var UserId = int.Parse(User.FindFirst("id").Value);
                var UserIdClaim = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                var folderToDelete = _folderRepository.GetOne(id);

                if (folderToDelete == null || UserIdClaim == null)
                {
                    return NotFound($"No se encontró la carpeta con id {id}");
                }
                if(folderToDelete.UserId != UserId)
                {
                    return Unauthorized("No tienes acceso para eliminar esta carpeta");
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