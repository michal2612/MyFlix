using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public class MovieDto
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        public int UserId { get; set; }

        public int VotesInGeneral { get; set; }

        public int PositiveVotes { get; set; }

        public bool? IsPositive { get; set; }

        public string Name { get; set; }

        public DateTime ReleasedDate { get; set; }

        public string GenreName { get; set; }
    }
}
