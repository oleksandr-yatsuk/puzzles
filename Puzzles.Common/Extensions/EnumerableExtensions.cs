﻿using System;
using System.Collections;
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

        public static void ForEach(this IEnumerable items, Action<object> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }

        public static IEnumerable Reverse(this IEnumerable items)
        {
            var itemsList = new ArrayList();

            foreach (var item in items)
            {
                itemsList.Add(item);
            }

            var reversed = new object[itemsList.Count];

            for (int i = itemsList.Count - 1, j = 0; i >= 0; i--, j++)
            {
                reversed[j] = itemsList[i];
            }

            return reversed;
        }

        public static IDictionary<TKey, TValue> ToDictionary<TItems, TKey, TValue>(this IEnumerable<TItems> items, Func<TItems, int, TKey> key, Func<TItems, int, TValue> value)
        {
            var dictionary = new Dictionary<TKey, TValue>();

            items.ForEach((item, i) => dictionary.Add(key(item, i), value(item, i)));

            return dictionary;
        }

        public static IDictionary<TKey, TValue> ToDictionary<TItems, TKey, TValue>(this IEnumerable<TItems> items, Func<TItems, TKey> key, Func<TItems, TValue> value)
        {
            var dictionary = new Dictionary<TKey, TValue>();

            items.ForEach(item => dictionary.Add(key(item), value(item)));

            return dictionary;
        }
    }
}