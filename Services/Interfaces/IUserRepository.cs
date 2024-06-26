using Microsoft.AspNetCore.Mvc;
using FastFiles.Models;

namespace FastFiles.Services
{
    public interface IUserRepository
    {
        public ActionResult<IEnumerable<User>> GetAll();
        public ActionResult<User> GetOne(int id);
    }
}