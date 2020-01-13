using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesSearchingMicroservice.Models;

namespace MoviesSearchingMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly SearchContext _context;

        public SearchController(SearchContext db)
        {
            _context = db;
        }

        [HttpPost]
        public bool AddRecord(SearchMovie searchMovie)
        {
            if (searchMovie == null || _context.SearchMovies.Where(c => c.MovieId == searchMovie.MovieId).Count() != 0)
                return false;

            _context.SearchMovies.Add(searchMovie);
            _context.SaveChanges();
            return true;
        }

        [HttpGet("{args}")]
        public IEnumerable<int> GetResults(string args)
        {
            var result = new List<int>();

            if (args == null || String.IsNullOrWhiteSpace(args))
                return result;

            var movies = _context.SearchMovies.ToList();
            foreach(var key in args.Split(' '))
            {
                foreach(var movie in movies)
                {
                    if (movie.MovieName.ToLower().Contains(key) || movie.Tags.Split(',').Contains(key))
                        result.Add(movie.MovieId);
                }
            }
            return result;
        }
    }
}