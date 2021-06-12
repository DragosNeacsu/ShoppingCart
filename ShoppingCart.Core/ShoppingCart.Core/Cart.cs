using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCart.Core
{
    public class Cart
    {
        private static List<Product> _products;

        public Cart()
        {
            _products = new List<Product>();
        }

        public async Task<double> RoundDecimals(decimal value)
        {
            return (double)Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }

        public async Task<double> GetTotal()
        {
            return 0;
        }

        public async Task AddProduct(Product product, int amount)
        {
            while (amount > 0)
            {
                _products.Add(product);
                amount--;
            }
        }

        public async Task<List<Product>> GetProducts()
        {
            return _products;
        }
    }

    public class Product
    {
        public Product(string productName, double productPrice)
        {
            Name = productName;
            Price = productPrice;
        }

        public double Price { get; set; }

        public string Name { get; set; }
    }
}
