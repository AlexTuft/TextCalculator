using FluentAssertions;
using TextCalculator.Expressions;
using Xunit;

namespace TextCalculator.UnitTests.Expressions
{
    public class Number : FixtureBase
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        void ShouldReturnInputNumberAsResult(int input)
        {
            var number = new NumberLiteral(input);

            number.Result.Should().Be(input);
        }

        [Theory]
        [InlineData(-1)]
        void CanBeNegativeNumbers(int input)
        {
            var number = new NumberLiteral(input);

            number.Result.Should().Be(input);
        }

        [Theory]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        void CanBeDecimalNumbers(double input)
        {
            var number = new NumberLiteral(input);

            number.Result.Should().Be(input);
        }
    }
}
