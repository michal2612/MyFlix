using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Webb.Models;
using Webb.ViewModels;

namespace Webb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (String.IsNullOrWhiteSpace(Request.Cookies["token"]))
                return View();
            return View("IndexLogged");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Submit(User user)
        {
            if (user == null)
                return RedirectToAction("Index", "Home");
            Response.Cookies.Append("token", ClassAPI.UserLogin(user));

            return RedirectToAction("Movies");
        }

        [TokenAuthorizeAttributeRedirect]
        public IActionResult Login()
        {
            return View();
        }

        [TokenAuthorize]
        public IActionResult Movies()
        {
            var user = Int32.TryParse(Request.Cookies["token"], out int result);
            if (result == 0 || bool.Parse(ClassAPI.CheckUser(result)) == false)
                return RedirectToAction("Billing","Home");

            return View(ClassAPI.MovieViewModel());
        }

        public IActionResult Related(string genre)
        {
            if (genre == null || String.IsNullOrWhiteSpace(genre))
                return RedirectToAction("Movies", "Home");

            return View("Movies", new MoviesViewModel() { Movies = ClassAPI.ReturnMovies(), Genres = new List<GenreDto>() { new GenreDto() { GenreName = genre } } });
        }

        [TokenAuthorizeAttributeRedirect]
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult RegisterNewUser(User user)
        {
            if (!ModelState.IsValid)
                return View("Register");

            var token = ClassAPI.RegisterUser(user);
            if (String.IsNullOrWhiteSpace(token))
                return View("Register");
            Response.Cookies.Append("token", token);

            return View("IndexLogged");
        }

        [TokenAuthorize]
        public IActionResult Billing()
        {
            return View(ClassAPI.UserCreditCards(Request.Cookies["token"]));
        }
        public IActionResult CreditCard(CreditCard creditCard)
        {
            creditCard.UserId = Convert.ToInt32(Request.Cookies["token"]);

            if (!ModelState.IsValid)
                return RedirectToAction("Billing");
            else
                ClassAPI.AddCreditCard(creditCard);

            return RedirectToAction("Billing");
        }

        [TokenAuthorize]
        public IActionResult LogOut()
        {
            Response.Cookies.Delete("token");
            return View("Index");
        }

        [TokenAuthorize]
        public IActionResult Player(MovieDto movie)
        {
            if (movie.Name == null)
            {
                var movies = ClassAPI.ReturnMovies();
                movie.Name = movies.ToList().Where(c => c.Id == movie.Id).First().Name;
            }

            try
            {
                var result = ClassAPI.ReturnVoting(movie.Id);

                if(result != null)
                {
                    var vote = result.Where(c => c.UserId == Int32.Parse(Request.Cookies["token"])).Single();
                    if (vote != null)
                        movie.IsPositive = vote.IsPositive;

                    movie.VotesInGeneral = result.Count();
                    movie.PositiveVotes = result.Where(c => c.IsPositive == true).Count();
                }
            }
                
            catch (Exception)
            {
                return View(movie);
            }
            return View(movie);
        }
    }
}
