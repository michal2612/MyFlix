using System;
using Microsoft.AspNetCore.Mvc;
using Webb.Models;
using Webb.ViewModels;

namespace Webb.Controllers
{
    public class MoviesController : Controller
    {

        public IActionResult Vote(VotedViewModel viewModel)
        {
            try
            {
                viewModel.UserId = Int32.Parse(Request.Cookies["token"]);
                ClassAPI.Vote(viewModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Player", "Home", new MovieDto() { Id = viewModel.MovieId });
            }
            return RedirectToAction("Player", "Home", new MovieDto() { Id = viewModel.MovieId });
        }

        public IActionResult Search()
        {
            return View(new Search() { Genres = ClassAPI.GetGenres() });
        }

        public IActionResult SearchMovie(Search searchModel)
        {
            var movies = ClassAPI.MovieViewModel();

            return View("Movies", new FoundMoviesViewModel() { Movies = movies.Movies, Genres = movies.Genres, FoundMoviesIds = ClassAPI.GetSearchResult(searchModel.Key) });
        }
    }
}