using System.Collections.Generic;

namespace Puzzles.Exercises.Probability.Palindromes.ExpectedValue
{
    public class WordComparer : IEqualityComparer<Word>
    {
        public bool Equals(Word x, Word y)
        {
            return x.Equals(y);
        }

        public int GetHashCode(Word word)
        {
            return word.GetHashCode();
        }
    }
}