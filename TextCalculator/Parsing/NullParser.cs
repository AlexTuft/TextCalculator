using System;
using TextCalculator.Expressions;

namespace TextCalculator.Parsing
{
    internal class NullParser : IParser
    {
        public IExpression? Parse(InputReader input)
        {
            throw new NotImplementedException();
        }
    }
}
