using FastFiles.Data;
using FastFiles.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        return _context.File.Include(f=> f.Folder).Include(f=> f.User).ToList();
    }

    public ActionResult<Files> GetOne(int id)
    {
       return _context.File.Include(f => f.Folder).Include(f=> f.User).FirstOrDefault(f=>f.Id == id);
    }

    public void Update(Files files)
    {
        _context.File.Update(files);
        _context.SaveChanges();
    }

}
