using FastFiles.Services;
using Microsoft.AspNetCore.Mvc;
using FastFiles.Models;
using FastFiles.Helpers;

namespace FastFiles.Controllers
{
    [ApiController]
    [Route("Created/File")]
    public class FilesCreatedControllers : ControllerBase
    {
        private readonly HelperUploadFiles helperUploadFiles;
        private readonly IFilesRepository _filesRepository;
        public FilesCreatedControllers(IFilesRepository filesRepository, HelperUploadFiles helperUpload)
        {
            _filesRepository = filesRepository;
            this.helperUploadFiles = helperUpload;
        }
        [HttpPost]
        public async Task <IActionResult> CreateFile([FromBody] Files files , IFormFile file)
        {
            try
            {
                _filesRepository.CreateFile(files);
                return Ok("El archivo se a creado exitosamente");
            }
            catch
            {
                return BadRequest("A ocurrido un error al intentar crear el archivo");
            }
        }
        
    }
}