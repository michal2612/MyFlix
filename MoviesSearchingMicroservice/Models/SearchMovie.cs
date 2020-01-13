using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesSearchingMicroservice.Models
{
    public class SearchMovie
    {
        public int Id { get; set; }

        public string MovieName { get; set; }

        public int MovieId { get; set; }

        public string Tags { get; set; }
    }
}
