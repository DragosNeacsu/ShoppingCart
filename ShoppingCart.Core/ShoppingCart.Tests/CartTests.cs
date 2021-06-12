using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FluentAssertions;
using ShoppingCart.Core;
using Xunit;

namespace ShoppingCart.Tests
{
    public class CartTests
    {
        [Fact]
        public async Task Shopping_Cart_Empty_Should_Return_0()
        {
            //Given
            var cart = new Cart();

            //When
            var result = await cart.GetTotal();

            //Then
            result.Should().Be(0);
        }

        [Fact]
        public async Task Can_Add_Products_To_Shopping_Cart()
        {
            //Given
            var cart = new Cart();
            var product = new Product("Dove Soap", 39.99);
            await cart.AddProduct(product, 1);

            //When
            var result = await cart.GetProducts();

            //Then
            result.Count.Should().Be(1);
        }

        [Fact]
        public async Task Can_Add_Multiple_Products_To_Shopping_Cart()
        {
            //Given
            var cart = new Cart();
            var product = new Product("Dove Soap", 39.99);
            await cart.AddProduct(product, 5);

            //When
            var result = await cart.GetProducts();

            //Then
            result.Count.Should().Be(5);
            result.ForEach(x => x.Name.Should().Be("Dove Soap"));
            result.ForEach(x => x.Price.Should().Be(39.99));
        }

        [Fact]
        public async Task Shopping_Cart_Returns_Items()
        {
            //Given
            var cart = new Cart();
            var product = new Product("Dove Soap", 39.99);
            await cart.AddProduct(product, 5);

            //When
            var result = await cart.GetDetails();

            //Then
            result.Products.Count.Should().Be(5);
            result.Products.ForEach(x => x.Name.Should().Be("Dove Soap"));
            result.Products.ForEach(x => x.Price.Should().Be(39.99));
        }

        [Fact]
        public async Task Shopping_Cart_Should_Calculate_Total()
        {
            //Given
            var cart = new Cart();
            var product = new Product("Dove Soap", 39.99);
            await cart.AddProduct(product, 5);

            //When
            var result = await cart.GetDetails();

            //Then
            result.Products.Count.Should().Be(5);
            result.Products.ForEach(x => x.Name.Should().Be("Dove Soap"));
            result.Products.ForEach(x => x.Price.Should().Be(39.99));
            result.Total.Should().Be(199.95);
        }

        [Fact]
        public async Task Shopping_Cart_Add_Additional_Item_Should_Calculate_Total()
        {
            //Given
            var cart = new Cart();
            var product = new Product("Dove Soap", 39.99);

            //When
            await cart.AddProduct(product, 5);
            await cart.AddProduct(product, 3);
            var result = await cart.GetDetails();

            //Then
            result.Products.Count.Should().Be(8);
            result.Products.ForEach(x => x.Name.Should().Be("Dove Soap"));
            result.Products.ForEach(x => x.Price.Should().Be(39.99));
            result.Total.Should().Be(319.92);
        }

        [Fact]
        public async Task Shopping_Cart_Can_Have_Sales_Tax()
        {
            //Given
            var cart = new Cart();

            //When
            await cart.SetSalesTaxRate(12.5);
            var result = await cart.GetDetails();

            //Then
            result.SalesTaxRate.Should().Be(12.5);
        }

        [Fact]
        public async Task Shopping_Cart_Can_calculate_sales_tax()
        {
            //Given
            var cart = new Cart();
            await cart.SetSalesTaxRate(12.5);
            await cart.AddProduct(new Product("Dove Soap", 39.99), 2);
            await cart.AddProduct(new Product("Axe Deo", 99.99), 2);

            //When
            var result = await cart.GetDetails();

            //Then
            result.SalesTaxValue.Should().Be(35.00);
        }

        [Fact]
        public async Task Shopping_Cart_Can_calculate_total_with_sales_tax()
        {
            //Given
            var cart = new Cart();
            await cart.SetSalesTaxRate(12.5);
            await cart.AddProduct(new Product("Dove Soap", 39.99), 2);
            await cart.AddProduct(new Product("Axe Deo", 99.99), 2);

            //When
            var result = await cart.GetDetails();

            //Then
            result.SalesTaxValue.Should().Be(35.00);
            result.Total.Should().Be(314.96);
        }

        [Fact]
        public async Task Shopping_Cart_Can_calculate_total_with_sales_tax_and_has_items()
        {
            //Given
            var cart = new Cart();
            await cart.SetSalesTaxRate(12.5);
            await cart.AddProduct(new Product("Dove Soap", 39.99), 2);
            await cart.AddProduct(new Product("Axe Deo", 99.99), 2);

            //When
            var result = await cart.GetDetails();

            //Then
            result.SalesTaxValue.Should().Be(35.00);
            result.Total.Should().Be(314.96);
            result.Products.Should().HaveCount(4);
            result.Products.Where(x => x.Name == "Dove Soap").ToList().ForEach(x => x.Price.Should().Be(39.99));
            result.Products.Where(x => x.Name == "Axe Deo").ToList().ForEach(x => x.Price.Should().Be(99.99));
        }
    }
}
