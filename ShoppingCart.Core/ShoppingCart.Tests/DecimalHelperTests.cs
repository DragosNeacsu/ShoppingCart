using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FluentAssertions;
using ShoppingCart.Core;
using Xunit;

namespace ShoppingCart.Tests
{
    public class DecimalHelperTests
    {
        [Theory]
        [InlineData(0.565, 0.57)]
        public async Task Round_Decimals_Should_Round_Up_Two_Decimals(decimal value, double expectedValue)
        {
            //When
            var result = DecimalsHelper.RoundDecimals(value);

            //Then
            result.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData(0.5649, 0.56)]
        public async Task Round_Decimals_Should_Round_Down_Two_Decimals(decimal value, double expectedValue)
        {
            //When
            var result = DecimalsHelper.RoundDecimals(value);

            //Then
            result.Should().Be(expectedValue);
        }
    }
}
