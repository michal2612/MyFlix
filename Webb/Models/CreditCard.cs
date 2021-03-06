﻿using System;
using System.ComponentModel.DataAnnotations;
using Webb.Interfaces;

namespace Webb.Models
{
    public class CreditCard : ICreditCardModelInterface
    {
        [Required]
        public int CardNumber { get; set; }

        [Required]
        public string CardOwner { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        [Display(Name = "CVV Number")]
        [Required]
        public int CvvNumber { get; set; }

        public int UserId { get; set; }
    }
}
