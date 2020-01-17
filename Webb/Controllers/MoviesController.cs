using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Webb.Models;
using Webb.ViewModels;

namespace Webb.Controllers
{
    public class MoviesController : Controller
    {
        private string GetMovies = "https://localhost:44348/api/";

        public IActionResult Related(string genre)
        {
            if (genre == null || String.IsNullOrWhiteSpace(genre))
                return RedirectToAction("Movies", "Home");

            var cli = new WebClient();
            cli.Headers[HttpRequestHeader.ContentType] = "application/json";
            var model = new MoviesViewModel() { Movies = JsonConvert.DeserializeObject<MovieDto[]>(cli.DownloadString(GetMovies + "movies")), Genres = new List<GenreDto>() { new GenreDto() { GenreName = genre } } };

            return View("Movies", model);
        }

        public IActionResult Vote(VotedViewModel viewModel)
        {
            try
            {
                var address = "https://localhost:44304/api/voting";
                var cli = new WebClient();
                cli.Headers[HttpRequestHeader.ContentType] = "application/json";
                viewModel.OpinionDate = DateTime.Now;
                cli.UploadString(address, JsonConvert.SerializeObject(viewModel));
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Search(string key)
        {
            return Content(key);
        }

        public IActionResult SearchResult(int[] movieIds)
        {
            if (movieIds == null || movieIds.Count() == 0)
                return RedirectToAction("Movies", "Home");

            return RedirectToAction("Movies", "Home");
        }
    }
}