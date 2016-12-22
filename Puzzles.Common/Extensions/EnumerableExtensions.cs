using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static TArray[] ToArray<T, TArray>(this IEnumerable<T> items, Func<T, TArray> convert)
        {
            return items.Select(convert).ToArray();
        }

        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> items, Action<T, int> action)
        {
            var i = 0;

            foreach (var item in items)
            {
                action(item, i++);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> items, Action<int> action)
        {
            var i = 0;

            foreach (var item in items)
            {
                action(i++);
            }
        }

        public static IDictionary<TKey, TValue> ToDictionary<TItems, TKey, TValue>(this IEnumerable<TItems> items, Func<TItems, int, TKey> key, Func<TItems, int, TValue> value)
        {
            var dictionary = new Dictionary<TKey, TValue>();

            items.ForEach((item, i) => dictionary.Add(key(item, i), value(item, i)));

            return dictionary;
        }
    }
}