using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
