using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Webb.Models;
using Webb.ViewModels;

namespace Webb.Controllers
{
    public class HomeController : Controller
    {
        private string GetLoginPath = "https://localhost:44392/api/";
        private string GetMovies = "https://localhost:44348/api/";
        private string GetBillings = "https://localhost:44302/api/billing/";

        public HomeController()
        {

        }

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

            var cli = new WebClient();
            cli.Headers[HttpRequestHeader.ContentType] = "application/json";
            var token = cli.UploadString(GetLoginPath + "login", JsonConvert.SerializeObject(new UserDto() { Username = user.Username, Password = user.Password }));
            Response.Cookies.Append("token", token);
            return View("IndexLogged");
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
            var cli = new WebClient();
            cli.Headers[HttpRequestHeader.ContentType] = "application/json";
            var output = cli.DownloadString($"https://localhost:44302/api/checkuser/{result}");

            if (result == 0 || bool.Parse(output) == false)
                return RedirectToAction("Billing","Home");

            var movies = JsonConvert.DeserializeObject<MovieDto[]>(cli.DownloadString(GetMovies + "movies"));
            var genres = JsonConvert.DeserializeObject<GenreDto[]>(cli.DownloadString(GetMovies + "genres"));
            return View(new MoviesViewModel() { Movies = movies, Genres = genres });
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

            var userDto = new UserDto() { Birthdate = user.Birthdate, Email = user.Email, Password = user.Password, Username = user.Username };
            var cli = new WebClient();
            cli.Headers[HttpRequestHeader.ContentType] = "application/json";
            var token = cli.UploadString(GetLoginPath + "register", JsonConvert.SerializeObject(userDto));

            if (String.IsNullOrWhiteSpace(token))
                return View("Register");
            Response.Cookies.Append("token", token);

            return View("IndexLogged");
        }

        [TokenAuthorize]
        public IActionResult Billing()
        {
            var cli = new WebClient();
            var result = JsonConvert.DeserializeObject<CreditCard[]>(cli.DownloadString(GetBillings + Request.Cookies["token"]));
            return View(new UserCreditCards() { CreditCards = result.ToList() });
        }

        public IActionResult CreditCard(CreditCard creditCard)
        {
            creditCard.UserId = Convert.ToInt32(Request.Cookies["token"]);
            var cli = new WebClient();
            cli.Headers[HttpRequestHeader.ContentType] = "application/json";
            var cards = JsonConvert.DeserializeObject<CreditCard[]>(cli.DownloadString(GetBillings + creditCard.UserId));
            if (!ModelState.IsValid)
                return RedirectToAction("Billing");

            cli.Headers[HttpRequestHeader.ContentType] = "application/json";
            var token = cli.UploadString(GetBillings, JsonConvert.SerializeObject(creditCard));
            var result = JsonConvert.DeserializeObject<CreditCard[]>(cli.DownloadString(GetBillings + creditCard.UserId));

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
            movie.UserId = Convert.ToInt32(Request.Cookies["token"]);
            if(movie.UserId != 0)
            {
                var address = "https://localhost:44304/api/voting/" + movie.UserId;
                var cli = new WebClient();
                cli.Headers[HttpRequestHeader.ContentType] = "application/json";

                try
                {
                    var result = JsonConvert.DeserializeObject<MovieDto[]>(cli.DownloadString(address));
                    if(result != null)
                    {
                        var vote = result.Where(c => c.MovieId == movie.Id).SingleOrDefault();
                        if (vote != null)
                            movie.IsPositive = vote.IsPositive;
                        var voting = JsonConvert.DeserializeObject<MovieDto[]>(cli.DownloadString("https://localhost:44304/api/movies/" + movie.Id));
                        movie.VotesInGeneral = voting.Count();
                        movie.PositiveVotes = voting.Where(c => c.IsPositive == true).Count();

                    }
                }
                catch (Exception)
                {
                    throw new ArgumentException();
                }
            }
            return View(movie);
        }
    }
}
