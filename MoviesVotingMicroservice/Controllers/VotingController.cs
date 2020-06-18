using System.Collections.Generic;
using System.Linq;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using MoviesVotingMicroservice.Models;
using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MoviesVotingMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotingController : ControllerBase
    {
        private readonly MovieOpinionContext _context;

        public VotingController(MovieOpinionContext db) => _context = db;

        [HttpGet]
        public IEnumerable<MovieOpinion> GetAllOpinions() => _context.MoviesVoting.ToList();
        //GET
        [HttpGet("{id}")]
        public IEnumerable<MovieOpinion> GetOpinion(int id) => _context.MoviesVoting.Where(o => o.UserId == id).ToList();
        //POST
        [HttpPost]
        public async Task<bool> AddOpinion(MovieOpinionDto movieOpinionDto)
        {
            if (movieOpinionDto == null)
                return false;
            var vote = Convert.ToBoolean(movieOpinionDto.IsPositive);

            try
            {
                if (_context.MoviesVoting.Where(c => c.MovieId == movieOpinionDto.MovieId && c.UserId == movieOpinionDto.UserId).ToList().Count() > 0)
                {
                    var voteInDb = await _context.MoviesVoting.Where(c => c.MovieId == movieOpinionDto.MovieId && c.UserId == movieOpinionDto.UserId).SingleOrDefaultAsync();
                    voteInDb.IsPositive = vote;
                    voteInDb.OpinionDate = DateTime.Now;
                }
                else
                {
                    var voted = new MovieOpinion() { IsPositive = vote, MovieId = movieOpinionDto.MovieId, OpinionDate = DateTime.Now, UserId = movieOpinionDto.UserId };
                    await _context.MoviesVoting.AddAsync(voted);
                }
            }
            finally
            {
                await _context.SaveChangesAsync();
            }
            return true;
        }
    }
}