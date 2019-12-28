using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingMS.Models
{
    public class CreditCardContext : DbContext
    {
        public DbSet<CreditCard> CreditCards { get; set; }

        public CreditCardContext(DbContextOptions db):base(db)
        {

        }
    }
}
