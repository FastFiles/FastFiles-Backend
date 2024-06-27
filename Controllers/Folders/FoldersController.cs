using Microsoft.AspNetCore.Mvc;
using FastFiles.Models;
using FastFiles.Services;

namespace FastFiles.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

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

    }
}