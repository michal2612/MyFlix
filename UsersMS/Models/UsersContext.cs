using Microsoft.EntityFrameworkCore;

namespace UsersMS.Models
{
    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<User> UsersDb { get; set; }

        public UsersContext(DbContextOptions db):base(db)
        {
            
        }
    }
}
