﻿using System.Collections.Generic;

namespace Puzzles.Common.Extensions
{
    public static class StackExtensions
    {
        public static void Push<T>(this Stack<T> stack, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                stack.Push(item);
            }
        }

        public static void PushIfNotNull<T>(this Stack<T> stack, T item)
        {
            if (item != null)
            {
                stack.Push(item);
            }
        }
    }
}