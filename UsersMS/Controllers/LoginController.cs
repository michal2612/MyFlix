using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersMS.Models;

namespace UsersMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UsersContext _context;

        public LoginController(UsersContext db)
        {
            _context = db;
        }

        public int? Login(User user)
        {
            var userInDb = _context.Users.Where(c => c.Username == user.Username && c.Password == user.Password);
            if (userInDb == null)
                return null;

            return userInDb.ToList().First().Id;
        }
    }
}