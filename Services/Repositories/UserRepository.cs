using Microsoft.EntityFrameworkCore;
using FastFiles.Data;
using FastFiles.Models;
using Microsoft.AspNetCore.Mvc;

namespace FastFiles.Services;

public class UserRepository : IUserRepository
{
    private readonly FastFilesContext _context;
    private readonly IMailerSendRepository _mailerSendRepository;


    public UserRepository(FastFilesContext context, IMailerSendRepository mailerSendRepository)
    {
        _context = context;
        _mailerSendRepository = mailerSendRepository;
    }

    public ActionResult<IEnumerable<User>> GetAll()
    {
        return _context.Users.ToList();
    }

    public ActionResult<User> GetOne(int id)
    {
        var user = _context.Users.Find(id);

        if (user == null)
        {
            return new NotFoundResult();
        }

        return user;
    }

    public void Create(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();

        _mailerSendRepository.SendMail(user.Email, user.Name);
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }
}