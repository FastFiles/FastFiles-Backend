using Microsoft.AspNetCore.Mvc;
using FastFiles.Models;
using FastFiles.Providers;
using FastFiles.Helpers;

namespace FastFiles.Services
{
    public interface IFilesRepository 
    {
        public ActionResult <IEnumerable<Files>> GetAll();
        public ActionResult <Files> GetOne (int id);
        public void Create (Files files);
        Task CreateFile (Files files,IFormFile file); //Este es para crear el archivo
        public void Update (Files files);
        void CreateFile(Files files); //Este se genera por el metodo 
    }
}