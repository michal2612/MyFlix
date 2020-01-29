using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MoviesVotingMicroservice.Models;

namespace MoviesVotingMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieOpinionContext _context;

        public MoviesController(MovieOpinionContext db)
        {
            _context = db;
        }

        //GET
        [HttpGet("{id}")]
        public IEnumerable<MovieOpinion> MovieOpinionById(int? id)
        {
            return _context.MovieOpinions.Where(c => c.MovieId == id).ToList();
        }
    }
}