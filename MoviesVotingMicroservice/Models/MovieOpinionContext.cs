using Microsoft.EntityFrameworkCore;

namespace MoviesVotingMicroservice.Models
{
    public class MovieOpinionContext : DbContext
    {
        public DbSet<MovieOpinion> MovieOpinions { get; set; }
        public DbSet<MovieOpinion> MoviesVoting { get; set; }

        public MovieOpinionContext(DbContextOptions db):base(db)
        {

        }
    }
}
