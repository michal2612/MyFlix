using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webb.Models;

namespace Webb.ViewModels
{
    public class CreatePlaylistViewModel
    {
        public Playlist Playlist { get; set; }
        public List<Movie> Movies { get; set; }

        public CreatePlaylistViewModel()
        {
            Movies = new List<Movie>();
        }
    }
}
