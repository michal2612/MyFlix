using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Webb.Models;

namespace Webb.ViewModels
{
    public class CreatePlaylistViewModel
    {
        [Display(Name = "Playlist name")]
        public string PlaylistName { get; set; }
        public int MovieId { get; set; }
        public List<Movie> Movies { get; set; }
        public List<int> MovieIds { get; set; }

        public CreatePlaylistViewModel()
        {
            Movies = new List<Movie>();
            MovieIds = new List<int>();
        }
    }
}
