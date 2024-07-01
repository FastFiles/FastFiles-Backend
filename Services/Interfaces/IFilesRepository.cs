using Microsoft.AspNetCore.Mvc;
using FastFiles.Models;

namespace FastFiles.Services
{
    public interface IFilesRepository 
    {
        public ActionResult <IEnumerable<Files>> GetAll();
        public ActionResult <Files> GetOne (int id);
        public void Create (Files files);
        public void Update (Files files);
        
        //public void Delete (int id);
    }
}