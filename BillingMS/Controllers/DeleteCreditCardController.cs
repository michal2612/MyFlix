using System.Linq;
using System.Threading.Tasks;
using BillingMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace BillingMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteCreditCardController : ControllerBase
    {
        private readonly CreditCardContext _context;

        public DeleteCreditCardController(CreditCardContext db) => _context = db;

        //DELETE
        [HttpPost]
        public async Task<bool> DeleteCreditCard(CreditCard creditCard)
        {
            var creditCardInDb = _context.CreditCardsDb.Where(m => m.CardNumber == creditCard.CardNumber && m.CardOwner == creditCard.CardOwner && m.UserId == creditCard.UserId).SingleAsync().Result;
            if (creditCard == null)
                return false;

            _context.CreditCardsDb.Remove(creditCardInDb);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}