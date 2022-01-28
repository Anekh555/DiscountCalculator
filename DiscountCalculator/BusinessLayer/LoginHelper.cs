using System;
using System.Linq;
using DiscountCalculator.EFLayer;
using DiscountCalculator.Interfaces;
using DiscountCalculator.Model;

namespace DiscountCalculator.BusinessLogic
{
    public class LoginHelper : ILoginHelper
    {
        private UserContext _userContext;

        private User _currentUser;

        public LoginHelper(UserContext userContext)
        {

            _userContext = userContext;

        }

        public bool isLogedIn()
        {
            return _currentUser?.isLoggedIn ?? false ;
        }

        public bool Login(string username, string password)
        {
            var response = false;

            _currentUser = _userContext.Users.Where(user => user.username.Equals(username, StringComparison.InvariantCultureIgnoreCase) && user.password.Equals(password,StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            if (_currentUser != null)
            {
                _currentUser.isLoggedIn = true;

                _userContext.SaveChangesAsync();

                response = true;
            }
            return response;
        }

        public bool LogOut()
        {
            _currentUser.isLoggedIn = false;

            _userContext.SaveChangesAsync();

            _currentUser = null;

            return true;
        }
    }
}
