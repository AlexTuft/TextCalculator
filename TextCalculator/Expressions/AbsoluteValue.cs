using System;

namespace TextCalculator.Expressions
{
    public class AbsoluteValue : IExpression
    {
        private readonly IExpression _expression;

        public AbsoluteValue(IExpression expression)
        {
            _expression = expression;
        }

        public double Result => Math.Abs(_expression.Result);

        public IExpression InnerExpression => _expression;
    }
}
