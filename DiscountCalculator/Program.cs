using System;
using DiscountCalculator.ServiceLayer;

namespace CoreTest
{
    class Program
    {
        static void Main(string[] args)
        {

            JewelleryOperations jewelleryOperations = new JewelleryOperations();
            try
            {
                Login(jewelleryOperations);

                CalculateTotalPrice(jewelleryOperations);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Invalid parameter entered. Application failed with the exception {ex.Message}");
            }
            finally
            {
                jewelleryOperations.LogOut();

                Console.WriteLine("Logged out Successfully!!!");

                Console.ReadLine();

            }


        }

        private static void CalculateTotalPrice(JewelleryOperations jewelleryOperations)
        {
            var calculate = true;

            while (calculate)
            {
                Console.WriteLine("To calculate totalprice, please price, weight and discount");

                Console.WriteLine("Price : ");

                var price = float.Parse(Console.ReadLine());

                Console.WriteLine("Weight : ");

                var weight = float.Parse(Console.ReadLine());

                Console.WriteLine("Discount : ");

                var discount = float.Parse(Console.ReadLine());

                Console.WriteLine(jewelleryOperations.CalculateTotalPrice(price, weight, discount));

                Console.WriteLine("Press 1 to calulate price again , press any other key to log out ");

                var option = Console.ReadLine();

                calculate = option == "1" ? true : false;
            }

        }

        private static void Login(JewelleryOperations jewelleryOperations)
        {
            var loggedIn = false;

            while (!loggedIn)
            {
                Console.WriteLine("Please Login!!");

                Console.WriteLine("Username - ");

                var username = Console.ReadLine();

                Console.WriteLine("Password - ");

                var password = Console.ReadLine();

                loggedIn = jewelleryOperations.Login(username, password);

                Console.WriteLine(loggedIn ? "Logged in successfully!!!" : "Incorrect username and password . ");
            }

        }
    }
}
