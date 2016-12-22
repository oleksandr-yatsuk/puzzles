using System.Collections.Generic;
using Puzzles.Common.Extensions;

namespace Puzzles.Exercises.Probability.Palindromes.ExpectedValue
{
    public class PalindromeEquations
    {
        public PalindromeEquations(Word[] palindromics, Alphabet alphabet)
        {
            Matrix = BuildSystemOfEquations(palindromics, alphabet);
        }

        public Matrix<double> Matrix { get; }

        static Matrix<double> BuildSystemOfEquations(Word[] palindromics, Alphabet alphabet)
        {
            var wordsHashTable = palindromics.ToDictionary((w, i) => w, (w, i) => i);

            var length = palindromics.Length;
            var equations = new Matrix<double>(length, length + 1);

            for (var i = 0; i < length; i++)
            {
                if (palindromics[i].IsPalindrome)
                {
                    equations[i, i] = 1;
                    continue;
                }

                BuildCoefficientForNotPalindrome(wordsHashTable, palindromics[i], equations, i, alphabet);
            }

            return equations;
        }

        static void BuildCoefficientForNotPalindrome(IDictionary<Word, int> words, Word word, Matrix<double> equations, int row, Alphabet alphabet)
        {
            var numberOfSwaps = new BinomialCoefficient(word.Length, 2);

            equations.SetOnDiagonal(numberOfSwaps, row);
            equations.SetLastInRow(numberOfSwaps, row);

            for (var i = 0; i < word.Length - 1; i++)
            {
                for (var j = i + 1; j < word.Length; j++)
                {
                    var wordIndex = words[word.Swapped(i, j).AsNormalized(alphabet.Letters)];

                    equations[row, wordIndex]--;
                }
            }
        }
    }
}