using FastFiles.Data;
using FastFiles.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FastFiles.Helpers;  
using FastFiles.Providers;

namespace FastFiles.Services;

public class FilesRepository : IFilesRepository
{
    private readonly HelperUploadFiles helperUploadfiles;
    private readonly FastFilesContext _context;
    public FilesRepository(FastFilesContext context, HelperUploadFiles helperUpload)
    {
        _context = context;
        this.helperUploadfiles = helperUpload;
    }
    public void Create(Files files)
    {
       _context.File.Add(files);
       _context.SaveChanges();
    }

    public async Task CreateFile(Files files, IFormFile file)
    {
        var namefile = file.Name;
        var pathFile = await this.helperUploadfiles.UploadFilesAsync(file, namefile , Folders.Uploads);
        files.Name = namefile; //Debo agregar un parametro del modelo que me haga referencia 
        _context.File.Add(files);
        await _context.SaveChangesAsync();
    }

    public void CreateFile(Files files)
    {
        throw new NotImplementedException();    //Se añade el mtodo
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
