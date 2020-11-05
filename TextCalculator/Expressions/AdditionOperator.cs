namespace TextCalculator.Expressions
{
    public class AdditionOperator : IExpression
    {
        private IExpression _lhs;
        private IExpression _rhs;

        public AdditionOperator(IExpression lhs, IExpression rhs)
        {
            _lhs = lhs;
            _rhs = rhs;
        }

        public double Result => _lhs.Result + _rhs.Result;
    }
}
