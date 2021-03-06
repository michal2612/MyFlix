﻿using Microsoft.EntityFrameworkCore;

namespace PlaylistsMicroservice.Models
{
    public class PlaylistsContext : DbContext
    {
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Playlist> PlaylistsDb { get; set; }

        public PlaylistsContext(DbContextOptions db) : base(db)
        {

        }
    }
}
