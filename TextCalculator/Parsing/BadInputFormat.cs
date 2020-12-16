using System;

namespace TextCalculator.Parsing
{
    public class BadInputFormat : Exception
    {
        public BadInputFormat(string input, int index) : base(CreateMessage(input, index))
        {
            ErrorIndex = index;
        }

        public int ErrorIndex { get; }

        private static string CreateMessage(string input, int index)
        {
            return $"Could not parse input at index {index}\n" +
                input + '\n' +
                new string(' ', index) + "^\n";
        }
    }
}
