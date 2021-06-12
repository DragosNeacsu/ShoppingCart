using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FluentAssertions;
using ShoppingCart.Core;
using Xunit;

namespace ShoppingCart.Tests
{
    public class CartTests
    {
        [Theory]
        [InlineData(0.565, 0.57)]
        public async Task Round_Decimals_Should_Round_Up_Two_Decimals(decimal value, double expectedValue)
        {
            //Given
            var cart = new Cart();

            //When
            var result = await cart.RoundDecimals(value);

            //Then
            result.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData(0.5649, 0.56)]
        public async Task Round_Decimals_Should_Round_Down_Two_Decimals(decimal value, double expectedValue)
        {
            //Given
            var cart = new Cart();

            //When
            var result = await cart.RoundDecimals(value);

            //Then
            result.Should().Be(expectedValue);
        }

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
            await cart.AddProduct(product);

            //When
            var result = await cart.GetProducts();

            //Then
            result.Count.Should().Be(1);
        }
    }
}
