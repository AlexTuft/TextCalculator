using TextCalculator.Expressions;

namespace TextCalculator.Parsing
{
    internal interface IParser
    {
        IExpression? Parse(InputReader input);
    }
}