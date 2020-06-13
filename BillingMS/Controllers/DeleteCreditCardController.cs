using System.Linq;
using BillingMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BillingMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteCreditCardController : ControllerBase
    {
        private readonly CreditCardContext _context;

        public DeleteCreditCardController(CreditCardContext db)
        {
            _context = db;
        }

        //DELETE
        [HttpPost]
        public bool DeleteCreditCard(CreditCard creditCard)
        {
            var creditCardInDb = _context.CreditCardsDb.Where(m => m.CardNumber == creditCard.CardNumber && m.CardOwner == creditCard.CardOwner && m.UserId == creditCard.UserId).Single();
            if (creditCard == null)
                return false;

            _context.CreditCardsDb.Remove(creditCardInDb);
            _context.SaveChanges();
            return true;
        }
    }
}