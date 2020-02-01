using Microsoft.EntityFrameworkCore;

namespace MoviesSearchingMicroservice.Models
{
    public class SearchContext : DbContext
    {
        public DbSet<SearchMovie> SearchMovies { get; set; }
        public DbSet<SearchMovie> SearchedMovies { get; set; }

        public SearchContext(DbContextOptions db) : base(db)
        {

        }
    }
}
