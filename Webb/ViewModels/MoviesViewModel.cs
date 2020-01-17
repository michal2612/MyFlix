using System.Collections.Generic;
using Webb.Models;

namespace Webb.ViewModels
{
    public class MoviesViewModel
    {
        public IEnumerable<MovieDto> Movies { get; set; }
        public IEnumerable<GenreDto> Genres { get; set; }
    }
}
