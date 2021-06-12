﻿using System;
using System.Collections.Generic;
using System.Linq;
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
            return await RoundDecimals((decimal)_products.Select(x => x.Price).Sum());
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

        public async Task<CartDetails> GetDetails()
        {
            return new CartDetails
            {
                Products = _products,
                Total = await GetTotal()
            };
        }
    }
}
