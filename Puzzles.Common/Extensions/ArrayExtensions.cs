namespace Puzzles.Common.Extensions
{
    public static class ArrayExtensions
    {
        public static T[] Copy<T>(this T[] array)
        {
            return (T[]) array?.Clone();
        }
    }
}