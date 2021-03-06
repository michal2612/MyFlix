﻿using System;

namespace BillingMS.Models
{
    public class CreditCard
    {
        public int Id { get; set; }
        public int CardNumber { get; set; }
        public string CardOwner { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int CvvNumber { get; set; }
        public int UserId { get; set; }
    }
}
