using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UsersMS.Models;

namespace UsersMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly UsersContext context;

        public ValuesController(UsersContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<User> ReturnUsers()
        {
            return context.Users.ToList();
        }

        [HttpGet("{id}")]
        public User ReturnUser(int id)
        {
            return context.Users.SingleOrDefault(c => c.Id == id);
        }

        [HttpPost]
        public ActionResult<int?> Get(User user)
        {
            if (context.Users.SingleOrDefault(c => c.Username == user.Username) == null)
            {
                context.Users.Add(new User() { Birthdate = user.Birthdate, Email = user.Email, Password = user.Password, Username = user.Username });
                context.SaveChanges();
                return user.Id;
            }
            return null;
        }
    }
}
