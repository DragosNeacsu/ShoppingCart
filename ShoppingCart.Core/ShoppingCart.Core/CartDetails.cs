using System.Collections.Generic;

namespace ShoppingCart.Core
{
    public class CartDetails
    {
        public List<Product> Products { get; set; }
        public double Total { get; set; }
    }
}