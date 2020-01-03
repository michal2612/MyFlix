using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Webb.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Recommendation()
        {
            return View();
        }
    }
}