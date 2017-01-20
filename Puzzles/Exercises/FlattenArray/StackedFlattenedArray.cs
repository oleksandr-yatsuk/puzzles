using System.Collections.Generic;
using System.Linq;
using Puzzles.Common.Extensions;

namespace Puzzles.Exercises.FlattenArray
{
    public class StackedFlattenedArray
    {
        readonly object[] _array;

        public StackedFlattenedArray(object[] array)
        {
            _array = array;
        }

        public T[] Flatten<T>() => Flattened<T>(_array).ToArray();

        static IEnumerable<T> Flattened<T>(object[] array)
        {
            var flattenedArray = new List<T>();
            var stack = new Stack<object>(array.Reverse());

            while (stack.Count > 0)
            {
                AddOrFlatten(stack, flattenedArray);
            }

            return flattenedArray;
        }

        static void AddOrFlatten<T>(Stack<object> stack, ICollection<T> flattenedArray)
        {
            var arrayItem = new ArrayItem(stack.Pop());

            if (arrayItem.IsArray)
            {
                arrayItem.Array
                    .Reverse()
                    .ForEach(stack.Push);
            }
            else
            {
                flattenedArray.Add(arrayItem.Value<T>());
            }
        }
    }
}
