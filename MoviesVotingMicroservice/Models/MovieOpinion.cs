using System;

namespace MoviesVotingMicroservice.Models
{
    public class MovieOpinion
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public bool IsPositive { get; set; }
        public int UserId { get; set; }
        public DateTime OpinionDate { get; set; }
    }
}
