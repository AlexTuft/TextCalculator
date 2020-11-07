using System;
using System.Linq;

namespace TextCalculator.Parsing
{
    internal class InputReader
    {
        internal InputReader(string text)
        {
            Text = text;
            Index = 0;
        }

        internal string Text { get; }

        internal int Index { get; private set; }

        internal bool HasNext()
        {
            return (Index) < Text.Length;
        }
        
        internal char PeekNext()
        {
            return Text[Index];
        }

        internal char Next()
        {
            return Text[Index++];
        }
    }

    internal static class InputReaderHelpers
    {
        internal static bool NextIs(this InputReader input, params char[] anyOf)
        {
            return input.HasNext() && anyOf.Contains(input.PeekNext());
        }

        internal static string TakeIf(this InputReader input, params char[] anyOf)
        {
            input.SkipWhiteSpace();

            if (input.NextIs(anyOf))
            {
                return input.Next().ToString();
            }

            return "";
        }

        internal static string TakeWhile(this InputReader input, Func<char, bool> predicate)
        {
            input.SkipWhiteSpace();

            string token = "";
            while (input.HasNext() && predicate(input.PeekNext()))
            {
                token += input.Next();
            }

            return token;
        }

        private static void SkipWhiteSpace(this InputReader input)
        {
            while (input.HasNext() && char.IsWhiteSpace(input.PeekNext()))
            {
                input.Next();
            }
        }
    }
}
