using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersMS.Models;

namespace UsersMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UsersContext _context;

        public RegisterController(UsersContext db) => _context = db;
        //POST
        [HttpPost]
        public async Task<int?> RegisterNewUser(User user)
        {
            var usersInDb = _context.Users.Where(u => u.Email == user.Email || u.Username == user.Username);

            if(usersInDb.Count() == 0 && String.IsNullOrWhiteSpace(user.Password) == false && String.IsNullOrWhiteSpace(user.Email) == false && String.IsNullOrWhiteSpace(user.Username) == false)
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return _context.Users.SingleAsync(c => c.Username == user.Username).Id;
            }
            return null;
        }
    }
}