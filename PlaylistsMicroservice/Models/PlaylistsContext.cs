using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistsMicroservice.Models
{
    public class PlaylistsContext : DbContext
    {
        public DbSet<Playlist> Playlists { get; set; }

        public PlaylistsContext(DbContextOptions db):base(db)
        {

        }
    }
}
