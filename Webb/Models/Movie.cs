using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webb.Interfaces;

namespace Webb.Models
{
    public class Movie : IMovieModelInterface
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleasedDate { get; set; }
        public string Genre { get; set; }
        public int VotesInGeneral { get; set; }
        public bool? IsPositive { get; set; }
        public int PositiveVotes { get; set; }
    }
}
