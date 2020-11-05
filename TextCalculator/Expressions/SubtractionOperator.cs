namespace TextCalculator.Expressions
{
    public class SubtractionOperator : IExpression
    {
        private IExpression _lhs;
        private IExpression _rhs;

        public SubtractionOperator(IExpression lhs, IExpression rhs)
        {
            _lhs = lhs;
            _rhs = rhs;
        }

        public double Result => _lhs.Result - _rhs.Result;
    }
}
