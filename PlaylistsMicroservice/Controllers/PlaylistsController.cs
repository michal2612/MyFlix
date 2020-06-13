using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PlaylistsMicroservice.Models;

namespace PlaylistsMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly PlaylistsContext _context;

        public PlaylistsController(PlaylistsContext db)
        {
            _context = db;
        }

        [HttpGet("{id}")]
        public List<Playlist> UsersPlaylists(int id)
        {
            var playlists = new List<Playlist>();

            foreach(var playlist in _context.PlaylistsDb)
                if (playlist.UserId == id)
                    playlists.Add(playlist);
            return playlists;
        }

        [HttpPost]
        public bool AddPlaylist(Playlist playlist)
        {
            if (playlist == null)
                return false;

            _context.PlaylistsDb.Add(playlist);
            _context.SaveChanges();
            return true;
        }
    }
}