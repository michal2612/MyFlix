using System.Collections.Generic;
using System.Linq;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using MoviesVotingMicroservice.Models;
using System;

namespace MoviesVotingMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotingController : ControllerBase
    {
        private readonly MovieOpinionContext _context;

        public VotingController(MovieOpinionContext db)
        {
            _context = db;
        }

        [HttpGet]
        public IEnumerable<MovieOpinion> GetAllOpinions()
        {
            return _context.MovieOpinions.ToList();
        }
        //GET
        [HttpGet("{id}")]
        public IEnumerable<MovieOpinion> GetOpinion(int id)
        {
            return _context.MovieOpinions.Where(o => o.UserId == id).ToList();
        }
        //POST
        [HttpPost]
        public bool AddOpinion(MovieOpinionDto movieOpinionDto)
        {
            if (movieOpinionDto == null)
                return false;
            var vote = Convert.ToBoolean(movieOpinionDto.IsPositive);

            if (_context.MovieOpinions.Where(c => c.MovieId == movieOpinionDto.MovieId && c.UserId == movieOpinionDto.UserId).ToList().Count() > 0)
            {
                var voteInDb = _context.MovieOpinions.Where(c => c.MovieId == movieOpinionDto.MovieId && c.UserId == movieOpinionDto.UserId).SingleOrDefault();
                voteInDb.IsPositive = vote;
                voteInDb.OpinionDate = DateTime.Now;
            }
            else
            {
                var voted = new MovieOpinion() { IsPositive = vote, MovieId = movieOpinionDto.MovieId, OpinionDate = DateTime.Now, UserId = movieOpinionDto.UserId };
                _context.MovieOpinions.Add(voted);
            }
            _context.SaveChanges();
            return true;
        }
    }
}