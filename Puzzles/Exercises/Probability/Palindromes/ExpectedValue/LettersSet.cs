using System.Collections.Generic;
using Puzzles.Common.Extensions;

namespace Puzzles.Exercises.Probability.Palindromes.ExpectedValue
{
    public class LettersSet
    {
        readonly char[] letters;

        public LettersSet(char[] letters)
        {
            this.letters = letters;
        }

        public IEnumerable<char[]> GetPermutations(int length)
        {
            var indexes = new CompositeIndexes(letters.Length, length);

            foreach (var index in indexes)
            {
                yield return index.ToArray(i => letters[i]);
            }
        }
    }
}