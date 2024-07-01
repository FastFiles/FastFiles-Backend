using FastFiles.Services;
using Microsoft.AspNetCore.Mvc;
using FastFiles.Models;

namespace FastFiles.Controllers
{
    [ApiController]
    [Route("api/Created/Archivo")]
    public class FilesCreatedControllers : ControllerBase
    {
        private readonly IFilesRepository _filesRepository;
        public FilesCreatedControllers(IFilesRepository filesRepository)
        {
            _filesRepository = filesRepository;
        }
        [HttpPost]
        public IActionResult Create (Files files)
        {
            try 
            {
                _filesRepository.Create(files);
                return Ok("El archivo se creo Exitosamente");
            }
            catch
            {
                return BadRequest("Ocurrio un error a la hora de crear el archivo.");
            }
        }
    }
}