using DiscountCalculator.BusinessLogic;
using DiscountCalculator.EFLayer;
using DiscountCalculator.Interfaces;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace UnitTests
{
    public class LoginHelperTests
    {
        private ILoginHelper _loginHelper;

       [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<UserContext>().UseInMemoryDatabase(databaseName: "JewelleryStore").Options;

            _loginHelper = new LoginHelper(new UserContext(options));

        }

        [Test]
        public void VerifyLogin()
        {
            //Verify login with correct username and password
            Assert.IsTrue(_loginHelper.Login("User1", "User1"));

            //verify isloggenIn parameter is set after successfull login
            Assert.IsTrue(_loginHelper.isLogedIn());

            //Verify log out
            Assert.IsTrue(_loginHelper.LogOut());
            Assert.False(_loginHelper.isLogedIn());

            // Verify login with correct incorrect username and password
            Assert.IsFalse(_loginHelper.Login("Us12", "1213"));
            Assert.IsFalse(_loginHelper.isLogedIn());
        }
    }
}
