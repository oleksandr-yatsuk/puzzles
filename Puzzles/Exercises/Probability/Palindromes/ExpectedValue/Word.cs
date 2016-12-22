using System.Collections.Generic;
using System.Linq;
using Puzzles.Common.Extensions;

namespace Puzzles.Exercises.Probability.Palindromes.ExpectedValue
{
    public struct Word
    {
        readonly string word;

        public Word(string word)
        {
            this.word = word;
        }

        public Word(params char[] word) : this(new string(word))
        { }

        public int Length => word.Length;

        public bool IsPalindromic => IsPalindromicOrNot(word);
        public bool IsPalindrome => IsPalindromeOrNot(word);

        public Word AsNormalized(string alphabet) => AsNormalized(alphabet.ToCharArray());

        public Word AsNormalized(char[] alphabet)
        {
            var normalized = new char[word.Length];
            var characters = new Dictionary<char, int>();

            var inAlphabet = 0;

            for (var i = 0; i < word.Length; i++)
            {
                var index = characters.Find(word[i], -1);

                if (index == -1)
                {
                    index = inAlphabet;
                    characters.Add(word[i], inAlphabet++);
                }

                normalized[i] = index < alphabet.Length ? alphabet[index] : word[i];
            }

            return new Word(normalized);
        }

        public Word AppendedWith(char valueToAppend) => new Word(word + valueToAppend);
        public Word PrependedWith(char valueToAppend) => new Word(valueToAppend + word);

        public Word Swapped(int i, int j)
        {
            var characters = word.ToCharArray();

            var temp = characters[i];

            characters[i] = characters[j];
            characters[j] = temp;

            return new Word(characters);
        }

        public bool LongerThan(int length) => word.Length > length;
        public bool ShorterThan(int length) => word.Length < length;
        public bool SameLengthWith(int length) => word.Length == length;

        public override string ToString() => word;
        public override int GetHashCode() => word.GetHashCode();
        public override bool Equals(object obj) => obj != null && obj.ToString() == word;

        public bool Equals(Word another) => word == another.word;

        static bool IsPalindromeOrNot(string word)
        {
            var middle = word.Length >> 1;

            for (int i = 0, j = word.Length - 1; i <= middle && j >= 0; i++, j--)
            {
                if (word[i] != word[j])
                {
                    return false;
                }
            }

            return true;
        }

        static bool IsPalindromicOrNot(string word)
        {
            var xorAll = XorAll(word);

            if ((word.Length & 1) == 0)
                return xorAll == 0;

            return (word.Count(c => c == xorAll) & 1) == 1;
        }

        static int XorAll(IEnumerable<char> word)
        {
            return word.Aggregate(0, (xor, c) => xor ^ c);
        }
    }
}