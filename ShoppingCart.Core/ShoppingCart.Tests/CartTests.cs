using System;
using System.Threading.Tasks;
using FluentAssertions;
using ShoppingCart.Core;
using Xunit;

namespace ShoppingCart.Tests
{
    public class CartTests
    {
        [Theory]
        [InlineData(0.565)]
        public async Task Round_Decimals_Should_Round_Up_Two_Decimals(decimal value)
        {
            //Given
            var cart = new Cart();

            //When
            var result = await cart.RoundDecimals(value);

            //Then
            result.Should().Be(0.57);
        }
    }
}
