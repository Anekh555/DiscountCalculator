using System;
namespace DiscountCalculator.Model
{
    public class User
    {
        public Guid Id { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public bool isLoggedIn { get; set; }
    }
}
