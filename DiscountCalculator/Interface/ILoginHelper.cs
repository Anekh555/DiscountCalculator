using System;
namespace DiscountCalculator.Interfaces
{
    public interface ILoginHelper
    {
        public bool Login(string username, string password);

        public bool LogOut();

        public bool isLogedIn();
    }
}
