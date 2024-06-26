using Microsoft.EntityFrameworkCore;
using FastFiles.Data;
using FastFiles.Models;
using Microsoft.AspNetCore.Mvc;

namespace FastFiles.Services;

public class FolderRepository : IFolderRepository
{
    private readonly FastFilesContext _context;

    public FolderRepository(FastFilesContext context)
    {
        _context = context;
    }

    public IEnumerable<Folder> GetAll()
    {
        return _context.Folders.Include(f => f.User).ToList();
    }

    public Folder GetOne(int id)
    {
        return _context.Folders.Include(f => f.User).FirstOrDefault(f => f.Id == id);
    }

    public void Create(Folder folder)
    {
        folder.DateCreated = DateTime.Now;
        folder.DateModified = DateTime.Now;
        folder.Status = "Active";

        _context.Folders.Add(folder);
        _context.SaveChanges();
    }

    public void Update(Folder folder)
    {
        folder.DateModified = DateTime.Now;

        _context.Folders.Update(folder);
        _context.SaveChanges();
    }

    public void Trash(Folder folder)
    {
        folder.Status = "Inactive";

        _context.Folders.Update(folder);
        _context.SaveChanges();
    }

    public void Delete(Folder folder)
    {
        _context.Folders.Remove(folder);
        _context.SaveChanges();
    }
}