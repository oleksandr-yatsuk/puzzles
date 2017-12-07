using System.Linq;

namespace Puzzles.Common.Extensions
{
    public static class ArrayExtensions
    {
        public static T[] Copy<T>(this T[] array)
        {
            return (T[]) array?.Clone();
        }

        public static void Exchange<T>(this T[] array, int i, int j)
        {
            var toJ = array[i];

            array[i] = array[j];
            array[j] = toJ;
        }

        public static T[] Concat<T>(this T[] array, params T[] items)
        {
            return Enumerable.Concat(array, items).ToArray();
        }
    }
}