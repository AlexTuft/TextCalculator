namespace TextCalculator.Expressions
{
    public class SubtractionOperator : IExpression, IBinaryOperator
    {
        public SubtractionOperator(IExpression leftExpression, IExpression rightExpression)
        {
            LeftExpression = leftExpression;
            RightExpression = rightExpression;
        }

        public double Result => LeftExpression.Result - RightExpression.Result;

        public IExpression LeftExpression { get; }

        public IExpression RightExpression { get; }
    }
}
