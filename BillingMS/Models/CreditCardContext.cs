using Microsoft.EntityFrameworkCore;

namespace BillingMS.Models
{
    public class CreditCardContext : DbContext
    {
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<CreditCard> CreditCardsDb { get; set; }

        public CreditCardContext(DbContextOptions db):base(db)
        {

        }
    }
}
