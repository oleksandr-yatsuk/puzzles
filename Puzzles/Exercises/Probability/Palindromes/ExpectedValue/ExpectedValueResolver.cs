using System.Collections.Generic;
using Puzzles.Common.Extensions;

namespace Puzzles.Exercises.Probability.Palindromes.ExpectedValue
{
    public class ExpectedValueResolver
    {
        readonly Alphabet alphabet;
        readonly IDictionary<Word, double> expectedValues = new Dictionary<Word, double>();

        public ExpectedValueResolver(Alphabet alphabet)
        {
            this.alphabet = alphabet;
        }

        public double GetExpectedNumberOfSwaps(string word)
        {
            var normalized = new Word(word).AsNormalized(alphabet.Letters);
            var expectedValue = FindExpectedValue(normalized);

            if (IsExpectedValueFound(expectedValue))
                return expectedValue;

            CalculateExpectedValues(normalized.Length);

            return expectedValues.Get(normalized);
        }

        double FindExpectedValue(Word normalized)
        {
            return normalized.IsPalindrome
                ? 0.0
                : expectedValues.Find(normalized, double.MinValue);
        }

        void CalculateExpectedValues(int wordLength)
        {
            var allWords = alphabet.GetPalindromicNormalizedWords(wordLength);

            var equations = new PalindromeEquations(allWords, alphabet);
            var systemOfEquations = new SystemOfEquations(equations.Matrix);
            var root = systemOfEquations.SingleRoot;

            allWords.ForEach((w, i) => expectedValues.Add(w, root[i]));
        }

        static bool IsExpectedValueFound(double value)
        {
            return new RoundedNumber(value).IsPositive;
        }
    }
}