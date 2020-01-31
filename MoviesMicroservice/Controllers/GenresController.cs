using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MoviesMicroservice.Models;

namespace MoviesMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly MoviesContext _context;

        public GenresController(MoviesContext db)
        {
            _context = db;
        }
        //GET
        public IEnumerable<GenreDto> Genres()
        {
            var genresDto = new List<GenreDto>();
            foreach (var genre in _context.GenresDb.ToList())
            {
                genresDto.Add(new GenreDto() { Id = genre.Id, GenreName = genre.GenreName });
            }
            return genresDto;
        }
    }
}