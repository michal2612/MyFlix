﻿namespace PlaylistsMicroservice.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int[] MoviesIds { get; set; }
    }
}
