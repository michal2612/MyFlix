using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesVotingMicroservice.Models
{
    public class MovieOpinionContext : DbContext
    {
        public DbSet<MovieOpinion> MovieOpinions { get; set; }

        public MovieOpinionContext(DbContextOptions db):base(db)
        {

        }
    }
}
