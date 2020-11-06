using AutoFixture;
using System;

namespace TextCalculator.UnitTests
{
    public class FixtureBase
    {
        protected readonly Fixture fixture = new Fixture();

        protected FixtureBase()
        {
            var random = new Random();
            fixture.Register(() => random.Next(-10000, 10000));
            fixture.Register(() => fixture.Create<int>() * random.NextDouble());
        }

        protected TObj Create<TObj>() => fixture.Create<TObj>();
    }
}
