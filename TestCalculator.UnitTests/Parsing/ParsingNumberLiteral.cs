using FluentAssertions;
using System;
using TextCalculator.Parsing;
using Xunit;

namespace TextCalculator.UnitTests.Parsing
{
    public class ParsingNumberLiteral : FixtureBase
    {
        [Theory]
        [InlineData("1")]
        [InlineData("12")]
        [InlineData("123")]
        void ShouldReturnNumberLiteral(string input)
        {
            var parser = new Parser();

            var expression = parser.Parse(input);

            expression.ShouldBeNumberLiteral(int.Parse(input));
        }

        [Theory]
        [InlineData("1.2")]
        [InlineData(".1")]
        [InlineData("1.")]
        void ShouldParseDecimalNumbers(string input)
        {
            var parser = new Parser();

            var expression = parser.Parse(input);

            expression.ShouldBeNumberLiteral(double.Parse(input));
        }

        [Theory]
        [InlineData("1.2.3")]
        [InlineData("1..23")]
        [InlineData(".23.")]
        void ShouldThrowBadInputFormatIfContainsMoreThanOneDecimalPoint(string input)
        {
            var parser = new Parser();

            Action action = () => parser.Parse(input);

            action.Should().Throw<BadInputFormat>();
        }

        [Theory]
        [InlineData("-1")]
        [InlineData("+1")]
        [InlineData("-1.2")]
        [InlineData("+1.2")]
        void ShouldParseSignSymbol(string input)
        {
            var parser = new Parser();

            var expression = parser.Parse(input);

            expression.ShouldBeNumberLiteral(double.Parse(input));
        }
    }
}
