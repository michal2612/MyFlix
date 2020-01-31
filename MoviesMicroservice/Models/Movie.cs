using System;

namespace MoviesMicroservice.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleasedDate { get; set; }
        public Genre Genre { get; set; }
    }
}
