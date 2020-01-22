using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webb.Models
{
    public class Playlist
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public string MoviesIds { get; set; }

        [Display(Name = "Playlist name")]
        public string PlaylistName { get; set; }
    }
}
