using System;

namespace ShoppingCart.Core
{
    public static class DecimalsHelper
    {
        public static double RoundDecimals(decimal value)
        {
            return (double)Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }

    }
}