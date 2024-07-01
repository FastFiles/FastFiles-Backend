using FastFiles.Data;
using FastFiles.Models;
using Microsoft.AspNetCore.Mvc;

namespace FastFiles.Services;

public class FilesRepository : IFilesRepository
{
    private readonly FastFilesContext _context;
    public FilesRepository(FastFilesContext context)
    {
        _context = context;
    }
    public void Create(Files files)
    {
       _context.File.Add(files);
       _context.SaveChanges();
    }

    public ActionResult<IEnumerable<Files>> GetAll()
    {
        return _context.File.ToList();
    }

    public ActionResult<Files> GetOne(int id)
    {
       var file = _context.File.FirstOrDefault(f => f.Id == id); 
       if (file == null)
       {
         return new NotFoundResult();
       }
       return file;
    }

    public void Update(Files files)
    {
        _context.File.Update(files);
        _context.SaveChanges();
    }

}
