using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesMicroservice.Models;

namespace MoviesMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesContext _context;

        public MoviesController(MoviesContext db) => _context = db;

        //GET
        [HttpGet]
        public IEnumerable<MovieDto> ListOfMovies()
        {
            var movies = new List<MovieDto>();
            foreach(var movie in _context.MoviesDb.Include(c => c.Genre).ToList())
                movies.Add(new MovieDto() { GenreName = movie.Genre.GenreName, Id = movie.Id, Name = movie.Name, ReleasedDate = movie.ReleasedDate });
            return movies;
        }
    }
}