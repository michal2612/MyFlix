using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webb.Models
{
    public class CreditCard
    {
        public int CardNumber { get; set; }
        public string CardOwner { get; set; }
        public DateTime ExpiryDate { get; set; }
        [Display(Name = "CVV Number")]
        public int CvvNumber { get; set; }
    }
}
