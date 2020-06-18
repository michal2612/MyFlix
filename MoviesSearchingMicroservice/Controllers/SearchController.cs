using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MoviesSearchingMicroservice.Models;

namespace MoviesSearchingMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly SearchContext _context;

        public SearchController(SearchContext db) => _context = db;

        [HttpPost]
        public async Task<bool> AddRecord(SearchMovie searchMovie)
        {
            if (searchMovie == null || await _context.SearchedMovies.Where(c => c.MovieId == searchMovie.MovieId).CountAsync() != 0)
                return false;

            await _context.SearchedMovies.AddAsync(searchMovie);
            await _context.SaveChangesAsync();
            return true;
        }

        [HttpGet("{args}")]
        public IEnumerable<int> GetResults(string args)
        {
            var result = new List<int>();

            if (args == null || String.IsNullOrWhiteSpace(args))
                return result;

            var movies = _context.SearchedMovies.ToList();
            foreach(var key in args.Split(' '))
                foreach(var movie in movies)
                    if (movie.MovieName.ToLower().Contains(key) || movie.Tags.Split(',').Contains(key))
                        result.Add(movie.MovieId);
            return result;
        }
    }
}