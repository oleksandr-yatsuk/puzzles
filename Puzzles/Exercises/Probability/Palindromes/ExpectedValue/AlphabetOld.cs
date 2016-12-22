using System;
using System.Collections.Generic;
using System.Linq;
using Puzzles.Common.Extensions;

namespace Puzzles.Exercises.Probability.Palindromes.ExpectedValue
{
    public class AlphabetOld
    {
        readonly char[] letters;

        public AlphabetOld(char[] letters)
        {
            FailIfEmpty(letters);
            FailIfNotDistinct(letters);

            this.letters = letters;
        }

        public Word[] GetPalindromicNormalizedWords(int wordLength)
        {
            var words = new HashSet<Word>();

            Func<Word, bool> whenPalindromic = w => w.IsPalindromic;
            Func<Word, Word> normalized = w => w.AsNormalized(letters);

            letters.ForEach(letter => GetWords(words, new Word(letter), letters, wordLength, whenPalindromic, normalized));

            return words.ToArray();
        }

        public Word[] GetAllWordsWithLengthLessThan(int wordLength)
        {
            var words = new HashSet<Word>();

            letters.ForEach(letter => GetWords(words, new Word(letter), letters, wordLength, w => true, w => w));

            return words.ToArray();
        }

        static void GetWords(HashSet<Word> words, 
            Word current, 
            char[] letters, 
            int maxLength, 
            Func<Word, bool> whenAdd,
            Func<Word, Word> changeWord)
        {
            if (current.LongerThan(maxLength)) return;

            if (whenAdd(current))
            {
                words.AddIfNotExists(changeWord(current));
            }

            letters.ForEach(letter => GetWords(words, current.PrependedWith(letter), letters, maxLength, whenAdd, changeWord));
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