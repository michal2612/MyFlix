using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesMicroservice.Models
{
    public class MoviesContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public MoviesContext(DbContextOptions db): base(db)
        {

        }
    }
}
