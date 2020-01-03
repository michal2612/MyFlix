using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Webb.Models;
using Webb.ViewModels;

namespace Webb.Controllers
{
    public class HomeController : Controller
    {
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
            var userDto = new UserDto()
            {
                Username = user.Username,
                Password = user.Password
            };
            var cli = new WebClient();
            cli.Headers[HttpRequestHeader.ContentType] = "application/json";
            var token = cli.UploadString("https://localhost:44392/api/values", JsonConvert.SerializeObject(userDto));
            this.Response.Cookies.Append("token", token);
            return Content(user.Username);
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
            var movies = JsonConvert.DeserializeObject<MovieDto[]>(cli.DownloadString("https://localhost:44348/api/movies"));
            var genres = JsonConvert.DeserializeObject<GenreDto[]>(cli.DownloadString("https://localhost:44348/api/genres"));
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
            var token = cli.UploadString("https://localhost:44392/api/register", JsonConvert.SerializeObject(userDto));
            if (String.IsNullOrWhiteSpace(token))
                return View("Register");
            Response.Cookies.Append("token", token);
            return View("IndexLogged");
        }

        [TokenAuthorize]
        public IActionResult Billing()
        {
            var cli = new WebClient();
            var token = Request.Cookies["token"];
            var result = JsonConvert.DeserializeObject<CreditCard[]>(cli.DownloadString($"https://localhost:44302/api/billing/{token}"));
            return View(new UserCreditCards() { CreditCards = result.ToList() });
        }

        public IActionResult CreditCard(CreditCard creditCard)
        {
            if (!ModelState.IsValid)
                return View("Billing");
            creditCard.UserId = Convert.ToInt32(Request.Cookies["token"]);
            var cli = new WebClient();
            cli.Headers[HttpRequestHeader.ContentType] = "application/json";
            var token = cli.UploadString("https://localhost:44302/api/billing", JsonConvert.SerializeObject(creditCard));
            var result = JsonConvert.DeserializeObject<CreditCard[]>(cli.DownloadString($"https://localhost:44302/api/billing/{creditCard.UserId}"));
            return View("Billing", new UserCreditCards() { CreditCards = result.ToList() });
        }

        public IActionResult LogOut()
        {
            var cookie = Request.Cookies["token"];
            return View("Index");
        }

        [TokenAuthorize]
        public IActionResult Player(MovieDto movie)
        {
            return View(movie);
        }
    }
}
