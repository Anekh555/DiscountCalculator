using System;
using DiscountCalculator.Interfaces;

namespace DiscountCalculator.BusinessLogic
{
    public class DiscountCalculator : IDiscountCalculator
    {
        public float CalculateTotalPrice(float goldPricePerGm, float weightInGm, float discountInPercent )
        {
            var costWithoutDiscount = goldPricePerGm * weightInGm;

            return costWithoutDiscount - (discountInPercent * costWithoutDiscount / 100);
        }

    }
}
