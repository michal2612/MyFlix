using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersMS.Models;

namespace UsersMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly UsersContext context;

        public ValuesController(UsersContext context) => this.context = context;

        [HttpGet]
        public async Task<IEnumerable<User>> ReturnUsers() => await context.Users.ToListAsync();

        [HttpGet("{id}")]
        public async Task<User> ReturnUser(int id) => await context.Users.SingleOrDefaultAsync(c => c.Id == id);

        [HttpPost]
        public async Task<ActionResult<int?>> Get(User user)
        {
            if (context.Users.SingleOrDefault(c => c.Username == user.Username) == null)
            {
                await context.Users.AddAsync(new User() { Birthdate = user.Birthdate, Email = user.Email, Password = user.Password, Username = user.Username });
                await context.SaveChangesAsync();
                return user.Id;
            }
            return null;
        }
    }
}
