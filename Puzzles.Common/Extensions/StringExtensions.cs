namespace Puzzles.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool FullyContains(this string value, string pattern, int startIndex)
        {
            var j = 0;

            for (int i = startIndex; i < value.Length && j < pattern.Length; i++, j++)
            {
                if (value[i] != pattern[j])
                    return false;
            }

            return j == pattern.Length;
        }
    }
}