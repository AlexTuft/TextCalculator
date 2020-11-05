using AutoFixture;

namespace TextCalculator.UnitTests
{
    public class FixtureBase
    {
        protected readonly Fixture fixture = new Fixture();

        protected FixtureBase()
        {
            var numberGenerator = new RandomNumericSequenceGenerator(-10000, 10000);
            fixture.Register(numberGenerator.Create<int>);
        }

        protected TObj Create<TObj>() => fixture.Create<TObj>();
    }
}
