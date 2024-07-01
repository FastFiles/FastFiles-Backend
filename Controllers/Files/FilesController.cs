using FastFiles.Services;
using FastFiles.Models;
using Microsoft.AspNetCore.Mvc;

namespace FastFiles.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilesController : ControllerBase
    {
        private readonly  IFilesRepository _filesRepository;
        public FilesController(IFilesRepository filesRepository)
        {
            _filesRepository = filesRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Files>> GetAll()
        {
            return _filesRepository.GetAll();
        }
        [HttpGet("{Id}")]
        public ActionResult<Files> GetOne(int Id)
        {
            return _filesRepository.GetOne(Id);
        }
    }
}