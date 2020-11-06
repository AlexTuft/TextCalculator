namespace TextCalculator.Expressions
{
    public interface IBinaryOperator
    {
        public IExpression LeftExpression { get; }

        public IExpression RightExpression { get; }
    }
}
