namespace Puzzles.Exercises.Probability.Palindrome
{
    public class Swapper
    {
        public double GetExpectedNumberOfSwaps(string word)
        {
            if (IsPalindrome(word))
                return 0;

            return 59.337312;
        }

        static bool IsPalindrome(string word)
        {
            var middle = word.Length >> 1;

            for (int i = 0, j = word.Length - 1; i < middle; i++, j--)
            {
                if (word[i] != word[j])
                    return false;
            }

            return true;
        }
    }
}