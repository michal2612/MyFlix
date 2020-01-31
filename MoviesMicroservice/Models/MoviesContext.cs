using Microsoft.EntityFrameworkCore;

namespace MoviesMicroservice.Models
{
    public class MoviesContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DbSet<Movie> MoviesDb { get; set; }
        public DbSet<Genre> GenresDb { get; set; }

        public MoviesContext(DbContextOptions db): base(db)
        {

        }
    }
}
