using System.Linq;
using System.Threading.Tasks;
using BillingMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BillingMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckUserController : ControllerBase
    {
        private readonly CreditCardContext _context;

        public CheckUserController(CreditCardContext db) => _context = db;

        [HttpGet("{id}")]
        public async Task<bool> CheckForPayment(int id)
        {
            if (await _context.CreditCardsDb.Where(c => c.UserId == id).CountAsync() > 0)
                return true;

            return false;
        }
    }
}