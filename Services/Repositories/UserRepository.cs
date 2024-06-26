using Microsoft.EntityFrameworkCore;
using FastFiles.Data;
using FastFiles.Models;
using Microsoft.AspNetCore.Mvc;

namespace FastFiles.Services;

public class UserRepository : IUserRepository
{
    private readonly FastFilesContext _context;

    public UserRepository(FastFilesContext context)
    {
        _context = context;
    }

    public ActionResult<IEnumerable<User>> GetAll()
    {
        return _context.Users.ToList();
    }
}