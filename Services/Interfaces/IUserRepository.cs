using Microsoft.AspNetCore.Mvc;
using FastFiles.Models;

namespace FastFiles.Services
{
    public interface IUserRepository
    {
        public ActionResult<IEnumerable<User>> GetAll();
        public ActionResult<User> GetOne(int id);
        public void Create(User user);
        public void Update(User user);
    }
}