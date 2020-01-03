using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webb.Models;

namespace Webb.ViewModels
{
    public class MoviesViewModel
    {
        public IEnumerable<MovieDto> Movies { get; set; }
        public IEnumerable<GenreDto> Genres { get; set; }
    }
}
