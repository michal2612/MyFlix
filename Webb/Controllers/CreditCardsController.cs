using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Webb.Models;

namespace Webb.Controllers
{
    public class CreditCardsController : Controller
    {
        private string DeleteCreditCardApi = "https://localhost:44302/api/DeleteCreditCard";

        public IActionResult DeleteCreditCard(CreditCard creditCard)
        {
            var client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.UploadString(DeleteCreditCardApi, JsonConvert.SerializeObject(creditCard));
            return View("Billing", "Home");
        }
    }
}