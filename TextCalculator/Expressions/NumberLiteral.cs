namespace TextCalculator.Expressions
{
    public class NumberLiteral : IExpression
    {
        public NumberLiteral(double number)
        {
            Result = number;
        }

        public double Result { get; }
    }
}
