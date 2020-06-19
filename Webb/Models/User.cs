using System;
using System.ComponentModel.DataAnnotations;
using Webb.Interfaces;

namespace Webb.Models
{
    public class User : IUserModelInterface
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Username { get; set; }
        [Required]
        [MinLength(5)]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
    }
}
