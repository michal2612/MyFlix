using System.Collections.Generic;
using Webb.Models;

namespace Webb.ViewModels
{
    public class FoundMoviesViewModel
    {
        public IEnumerable<MovieDto> Movies { get; set; }
        public IEnumerable<GenreDto> Genres { get; set; }
        public IEnumerable<int> FoundMoviesIds { get; set; }
    }
}
