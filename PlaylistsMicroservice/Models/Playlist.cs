﻿namespace PlaylistsMicroservice.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string MoviesIds { get; set; }
        public string PlaylistName { get; set; }
    }
}
