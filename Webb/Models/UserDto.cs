using System;
using Webb.Interfaces;

namespace Webb.Models
{
    public class UserDto : IUserModelInterface
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
