using System;
using DiscountCalculator.BusinessLogic;
using DiscountCalculator.EFLayer;
using DiscountCalculator.Interfaces;
using DiscountCalculator.Model;
using Microsoft.EntityFrameworkCore;

namespace DiscountCalculator.ServiceLayer
{
    public class JewelleryOperations
    {
       private ILoginHelper _loginHelper;

        private IDiscountCalculator _discountCalculator;

        public JewelleryOperations()
        {
            var options = new DbContextOptionsBuilder<UserContext>().UseInMemoryDatabase(databaseName: "JewelleryStore").Options;

            _loginHelper = new LoginHelper(new UserContext(options));

            _discountCalculator = new DiscountCalculator.BusinessLogic.DiscountCalculator();
        }

       public bool Login(string username,string password)
        {
            return _loginHelper.Login(username, password);
        }

        public string CalculateTotalPrice(float goldprice, float weight, float discount = 0)
        {
            var discountedPrice = "Please login to calculate the discounted price";

            if (_loginHelper.isLogedIn())
            {
                discountedPrice =  $"Total price is {_discountCalculator.CalculateTotalPrice(goldprice, weight, discount)}";
            }

            return discountedPrice;
        }

        public bool LogOut()
        {
            return _loginHelper.LogOut();
        }
    }
}
