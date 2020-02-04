﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Webb.Models;
using Webb.ViewModels;

namespace Webb.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Related(string genre)
        {
            if (genre == null || String.IsNullOrWhiteSpace(genre))
                return RedirectToAction("Movies", "Home");

            return View("Movies", new MoviesViewModel() { Movies = ClassAPI.ReturnMovies(), Genres = new List<GenreDto>() { new GenreDto() { GenreName = genre } } });
        }

        public IActionResult Vote(VotedViewModel viewModel)
        {
            try
            {
                viewModel.UserId = Int32.Parse(Request.Cookies["token"]);
                ClassAPI.Vote(viewModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Player", new MovieDto() { Id = viewModel.MovieId });
            }
            return RedirectToAction("Index", "Player", new MovieDto() { Id = viewModel.MovieId });
        }

        public List<GenreDto> lista = new List<GenreDto>() {
            new GenreDto() {Id = 1, GenreName = "horror"},
            new GenreDto() {Id = 2, GenreName = "action"}
        };

        public IActionResult Search()
        {
            return View(new Search() { Genres = lista });
        }

        public IActionResult SearchMovie(Search searchModel)
        {
            var movies = ClassAPI.MovieViewModel();

            return View("Movies", new FoundMoviesViewModel() { Movies = movies.Movies, Genres = movies.Genres, FoundMoviesIds = ClassAPI.GetSearchResult(searchModel.Key) });
        }
    }
}