using System;
using System.Threading.Tasks;

namespace ShoppingCart.Core
{
    public class Cart
    {
        public async Task<double> RoundDecimals(decimal value)
        {
            return (double)Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }
    }
}
