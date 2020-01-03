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
    public class CheckUserController : ControllerBase
    {
        private readonly CreditCardContext _context;

        public CheckUserController(CreditCardContext db)
        {
            _context = db;
        }

        [HttpGet("{id}")]
        public bool CheckForPayment(int id)
        {
            var userInDb = _context.CreditCards.Where(c => c.UserId == id);
            if (userInDb.Count() > 0)
                return true;
            return false;
        }
    }
}