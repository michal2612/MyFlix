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
        // GET api/values
        [HttpPost]
        public ActionResult<string> Get(UserDto userDto)
        {
            if (context.Users.SingleOrDefault(c => c.Username == userDto.Username) != null)
                return "token";
            return BadRequest();
        }
    }
}
