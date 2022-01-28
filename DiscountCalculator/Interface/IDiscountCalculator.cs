using System;
namespace DiscountCalculator.Interfaces
{
    public interface IDiscountCalculator
    {
        public float CalculateTotalPrice(float goldPricePerGm, float weightInGm, float discountInPercent = 0);
    }
}
