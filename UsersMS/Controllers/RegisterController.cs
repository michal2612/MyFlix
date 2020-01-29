using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UsersMS.Models;

namespace UsersMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UsersContext _context;

        public RegisterController(UsersContext db)
        {
            _context = db;
        }
        //POST
        [HttpPost]
        public int? RegisterNewUser(User user)
        {
            var usersInDb = _context.Users.Where(u => u.Email == user.Email || u.Username == user.Username);

            if(usersInDb.Count() == 0 && String.IsNullOrWhiteSpace(user.Password) == false && String.IsNullOrWhiteSpace(user.Email) == false && String.IsNullOrWhiteSpace(user.Username) == false)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return _context.Users.Single(c => c.Username == user.Username).Id;
            }
            return null;
        }
    }
}