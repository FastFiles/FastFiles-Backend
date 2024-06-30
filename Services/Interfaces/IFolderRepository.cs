using Microsoft.AspNetCore.Mvc;
using FastFiles.Models;

namespace FastFiles.Services
{
    public interface IFolderRepository
    {
        public IEnumerable<Folder> GetAll();
        public Folder GetOne(int id);
        public void Create(Folder folder);
        public void Update(Folder folder);
        public void Trash(Folder folder);
        public void Delete(Folder folder);
    }
}