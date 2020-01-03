﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webb.Models;

namespace Webb.ViewModels
{
    public class UserCreditCards
    {
        public User User { get; set; }
        public CreditCard CreditCard { get; set; }
        public IEnumerable<CreditCard> CreditCards { get; set; }
    }
}