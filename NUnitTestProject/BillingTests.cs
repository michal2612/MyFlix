using BillingMS.Controllers;
using BillingMS.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject
{
    [TestFixture]
    public class BillingTests
    {
        public CreditCard CreditCard { get; set; }
        public Mock<BillingController> BillingController { get; set; }
        public Mock<CreditCardContext> CreditCardContext { get; set; }

        public void Setup()
        {
            CreditCard = new CreditCard() { Id = 1 };
        }

        [Test]
        public void check_the_list_of_credit_cards()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}
