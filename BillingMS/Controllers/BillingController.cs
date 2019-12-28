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
    public class BillingController : ControllerBase
    {
        private readonly CreditCardContext _context;

        public BillingController(CreditCardContext db)
        {
            _context = db;
        }
        //POST
        public bool AddCreditCard(CreditCard creditCard)
        {
            _context.CreditCards.Add(new CreditCard() { CardNumber = creditCard.CardNumber, CardOwner = creditCard.CardOwner, CvvNumber = creditCard.CvvNumber, ExpiryDate = creditCard.ExpiryDate });
            _context.SaveChanges();
            return true;
        }
    }
}