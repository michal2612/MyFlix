using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Webb.Interfaces;
using Webb.Models;

namespace Webb.Controllers
{
    public class CreditCardsController : Controller
    {
        private string DeleteCreditCardApi = "https://localhost:44302/api/DeleteCreditCard";

        public IActionResult DeleteCreditCard(ICreditCardModelInterface creditCard)
        {
            var client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.UploadString(DeleteCreditCardApi, JsonConvert.SerializeObject(creditCard));
            return View("Billing", "Home");
        }
    }
}