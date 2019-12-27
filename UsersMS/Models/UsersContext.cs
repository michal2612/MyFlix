using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersMS.Models
{
    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; }


        public UsersContext(DbContextOptions db):base(db)
        {
            
        }
    }
}
