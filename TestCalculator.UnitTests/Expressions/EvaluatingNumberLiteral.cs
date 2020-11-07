using FluentAssertions;
using TextCalculator.Expressions;
using Xunit;

namespace TextCalculator.UnitTests.Expressions
{
    public class EvaluatingNumberLiteral : FixtureBase
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        void ShouldReturnInputNumber(int input)
        {
            var number = new NumberLiteral(input);

            number.Result.Should().Be(input);
        }

        [Theory]
        [InlineData(-1)]
        void ShouldHandleNegativeNumbers(int input)
        {
            var number = new NumberLiteral(input);

            number.Result.Should().Be(input);
        }

        [Theory]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        void ShouldHandleDecimalNumbers(double input)
        {
            var number = new NumberLiteral(input);

            number.Result.Should().Be(input);
        }
    }
}
