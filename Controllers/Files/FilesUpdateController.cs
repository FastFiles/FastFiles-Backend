using FastFiles.Services;
using FastFiles.Models;
using Microsoft.AspNetCore.Mvc;

namespace FastFiles.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilesUpdateController : ControllerBase
    {
        private readonly IFilesRepository _filesRepository;
        public FilesUpdateController(IFilesRepository filesRepository)
        {
            _filesRepository = filesRepository;
        }
        [HttpPost("{Id}")]
        public IActionResult Update (Files file)
        {
            try 
            {
                _filesRepository.Update(file);
                return Ok("Se a actualizado con exito el archivo");
            }
            catch 
            {
                return BadRequest("Ocurrio un error, no pudo actualizar el archivo");
            }
        }
    }
}