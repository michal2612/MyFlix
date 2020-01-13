using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesSearchingMicroservice.Models
{
    public class SearchContext : DbContext
    {
        public DbSet<SearchMovie> SearchMovies { get; set; }

        public SearchContext(DbContextOptions db) : base(db)
        {

        }
    }
}
