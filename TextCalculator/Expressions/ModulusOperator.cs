namespace TextCalculator.Expressions
{
    public class ModulusOperator : IExpression, IBinaryOperator
    {
        public ModulusOperator(IExpression leftExpression, IExpression rightExpression)
        {
            LeftExpression = leftExpression;
            RightExpression = rightExpression;
        }

        public double Result => LeftExpression.Result % RightExpression.Result;

        public IExpression LeftExpression { get; }

        public IExpression RightExpression { get; }
    }
}
