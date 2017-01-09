using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Exercises.Probability.Palindromes.ExpectedValue
{
    public class Alphabet
    {
        public Alphabet(char[] letters)
        {
            FailIfEmpty(letters);
            FailIfNotDistinct(letters);

            Letters = letters;
        }

        public char[] Letters { get; }

        public Word[] GetPalindromicNormalizedWords(int wordLength)
        {
            var allWords = GetAllPossibleWords(wordLength);

            return allWords.Where(w => w.IsPalindromic)
                           .Select(w => w.AsNormalized(Letters))
                           .Distinct(new WordComparer())
                           .ToArray();
        }

        public Word[] GetAllWords(int wordLength)
        {
            return GetAllPossibleWords(wordLength).ToArray();
        }

        IEnumerable<Word> GetAllPossibleWords(int wordLength)
        {
            var lettersSet = new LettersSet(Letters);
            var permutations = lettersSet.GetPermutations(wordLength);

            return permutations.Select(p => new Word(p));
        }

        static void FailIfEmpty(char[] letters)
        {
            if(letters == null || !letters.Any())
                throw new ArgumentException(@"Alphabet must be non empty", nameof(letters));
        }

        static void FailIfNotDistinct(char[] letters)
        {
            var distinct = letters.Distinct();

            if (distinct.Count() != letters.Length)
                throw new ArgumentException(@"All letters in alphabet must be distinct", nameof(letters));
        }
    }
}