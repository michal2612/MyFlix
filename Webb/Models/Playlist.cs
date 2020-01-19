using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webb.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string MoviesIds { get; set; }
        public string PlaylistName { get; set; }
    }
}
