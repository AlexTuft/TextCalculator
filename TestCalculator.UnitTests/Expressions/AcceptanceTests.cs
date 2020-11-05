using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using TextCalculator.Expressions;
using Xunit;

namespace TextCalculator.UnitTests.Expressions
{
    public class AcceptanceTests : FixtureBase
    {
        [Fact]
        void Case1()
        {
            // 2 + 4 = 6

            new AdditionOperator(
                new NumberLiteral(2), 
                new NumberLiteral(4))
                .Result.Should().Be(6);
        }

        [Fact]
        void Case2()
        {
            // 5 - 41 = -36

            new SubtractionOperator(
                new NumberLiteral(5),
                new NumberLiteral(41))
                .Result.Should().Be(-36);
        }

        [Fact]
        void Case3()
        {
            // 32 * -45 = -1440

            new MultiplicationOperator(
                new NumberLiteral(32),
                new NumberLiteral(-45))
                .Result.Should().Be(-1440);
        }

        [Fact]
        void Case4()
        {
            // -12 + 45 - 3 = 30

            new SubtractionOperator(
                new AdditionOperator(
                    new NumberLiteral(-12),
                    new NumberLiteral(45)),
                new NumberLiteral(3))
                .Result.Should().Be(30);
        }

        [Fact]
        void Case5()
        {
            // -3 + 100 / 4 = 22

            new AdditionOperator(
                new NumberLiteral(-3),
                new DivisionOperator(
                    new NumberLiteral(100),
                    new NumberLiteral(4)))
                .Result.Should().Be(22);
        }
    }
}
