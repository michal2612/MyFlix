﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillingMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace BillingMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly CreditCardContext _context;

        public BillingController(CreditCardContext db) => _context = db;

        //GET
        [HttpGet("{id}")]
        public IEnumerable<CreditCard> CreditCards(int id) => _context.CreditCardsDb.Where(c => c.UserId == id);

        //POST
        [HttpPost]
        public async Task<bool> AddCreditCard(CreditCard creditCard)
        {
            if(creditCard != null)
            {
                _context.CreditCardsDb.Add(new CreditCard() { CardNumber = creditCard.CardNumber, CardOwner = creditCard.CardOwner, CvvNumber = creditCard.CvvNumber, ExpiryDate = creditCard.ExpiryDate, UserId = creditCard.UserId });
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}