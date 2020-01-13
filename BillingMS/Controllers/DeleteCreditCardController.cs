using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var creditCardInDb = _context.CreditCards.Where(m => m.CardNumber == creditCard.CardNumber && m.CardOwner == creditCard.CardOwner && m.UserId == creditCard.UserId).Single();
            if (creditCard == null)
                return false;
            _context.CreditCards.Remove(creditCardInDb);
            _context.SaveChanges();
            return true;
        }
    }
}