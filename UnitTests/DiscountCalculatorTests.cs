using System;
using DiscountCalculator.Interfaces;
using NUnit.Framework;

namespace UnitTests
{
    public class DiscountCalculatorTests
    {
        private IDiscountCalculator _discountCalculator;

        [SetUp]
        public void SetUp()
        {
            _discountCalculator = new DiscountCalculator.BusinessLogic.DiscountCalculator();

        }

        [Test]
        public void VerifyTotalPrice()
        {
            //calculate total cost without discount
            Assert.AreEqual(_discountCalculator.CalculateTotalPrice(10, 10),10*10);

            //calculate total cost with discount
            Assert.AreEqual(_discountCalculator.CalculateTotalPrice(10, 10, 10), 90);

        }
    }
}
