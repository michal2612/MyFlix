using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
