using System;
using DiscountCalculator.BusinessLogic;
using DiscountCalculator.EFLayer;
using DiscountCalculator.Interfaces;
using DiscountCalculator.ServiceLayer;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
namespace UnitTests
{
    public class JewelleryOperationsTests
    {
        private JewelleryOperations jewelleryOperations;     

        [SetUp]       
        public void SetUp()
        {
            jewelleryOperations = new JewelleryOperations();
        }

        [Test]
        public void CalculateTotalPrice()
        {
            //trying to calculate price before logging in
            Assert.AreEqual(jewelleryOperations.CalculateTotalPrice(10, 10), "Please login to calculate the discounted price");

            //trying to calculate price after loging in
            Assert.IsTrue(jewelleryOperations.Login("User1", "User1"));
            Assert.AreEqual(jewelleryOperations.CalculateTotalPrice(10, 10), $"Total price is {100}");
            
        }
    }
}
