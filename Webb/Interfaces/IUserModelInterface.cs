using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webb.Interfaces
{
    public interface IUserModelInterface
    {
        string Username { get; set; }
        string Password { get; set; }
    }
}
