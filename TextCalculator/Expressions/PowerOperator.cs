using System;

namespace TextCalculator.Expressions
{
    public class PowerOperator : IExpression, IBinaryOperator
    {
        public PowerOperator(IExpression leftExpression, IExpression rightExpression)
        {
            LeftExpression = leftExpression;
            RightExpression = rightExpression;
        }

        public double Result => Math.Pow(LeftExpression.Result, RightExpression.Result);

        public IExpression LeftExpression { get; }

        public IExpression RightExpression { get; }
    }
}
