using System;
using System.Collections;

namespace Puzzles.Exercises.Arrays.FlattenArray
{
    public struct ArrayItem
    {
        readonly object item;

        public ArrayItem(object item)
        {
            FailIfNull(item);

            this.item = item;
        }

        public bool IsArray => item is IEnumerable;

        public T Value<T>() => (T) item;
        public IEnumerable Array => (IEnumerable) item;

        static void FailIfNull(object item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
        }
    }
}