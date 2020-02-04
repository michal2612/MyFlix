using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Webb.Models
{
    public class Search
    {
        public List<GenreDto> Genres { get; set; }

        [Display(Name = "Enter the tile of the movie")]
        public string Key { get; set; }

        public string GenreName { get; set; }

        public Search()
        {
            Genres = new List<GenreDto>();
        }
    }
}
