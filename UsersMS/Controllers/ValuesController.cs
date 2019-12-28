using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
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

        [HttpPost]
        public ActionResult<string> Get(UserDto userDto)
        {
            if (context.Users.SingleOrDefault(c => c.Username == userDto.Username) == null)
            {
                context.Users.Add(new User() { Birthdate = userDto.Birthdate, email = userDto.Email, Password = userDto.Password, Username = userDto.Username });
                context.SaveChanges();
                return userDto.Username;
            }
            return "Something went wrong";
        }
    }
}
