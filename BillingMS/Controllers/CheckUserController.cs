using System.Linq;
using BillingMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace BillingMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckUserController : ControllerBase
    {
        private readonly CreditCardContext _context;

        public CheckUserController(CreditCardContext db) => _context = db;

        [HttpGet("{id}")]
        public bool CheckForPayment(int id)
        {
            if (_context.CreditCardsDb.Where(c => c.UserId == id).Count() > 0)
                return true;

            return false;
        }
    }
}