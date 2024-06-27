using Microsoft.AspNetCore.Mvc;
using FastFiles.Models;

namespace FastFiles.Services
{
    public interface IFolderRepository
    {
        public IEnumerable<Folder> GetAll();
        public Folder GetOne(int id);
    }
}