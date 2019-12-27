using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Webb.Models;

namespace Webb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [TokenAuthorize]
        public IActionResult Privacy()
        {
            return View();
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

        public IActionResult Login()
        {
            return View();
        }

        [TokenAuthorize]
        public IActionResult Movies()
        {
            return View();
        }
    }
}
