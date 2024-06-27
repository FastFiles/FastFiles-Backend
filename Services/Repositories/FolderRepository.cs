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
}