using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Exercises.Arrays.FlattenArray
{
    public class RecoursivelyFlattenedArray
    {
        readonly object[] _array;

        public RecoursivelyFlattenedArray(object[] array)
        {
            _array = array;
        }

        public T[] Flatten<T>() => Flattened<T>(_array).ToArray();

        static IEnumerable<T> Flattened<T>(IEnumerable array)
        {
            var flattenedArray = new List<T>();

            foreach (var item in array)
            {
                AddOrFlatten(item, flattenedArray);
            }

            return flattenedArray;
        }

        static void AddOrFlatten<T>(object item, List<T> flattenedArray)
        {
            var arrayItem = new ArrayItem(item);

            if (arrayItem.IsArray)
            {
                var flattened = Flattened<T>(arrayItem.Array);

                flattenedArray.AddRange(flattened);
            }
            else
            {
                flattenedArray.Add(arrayItem.Value<T>());
            }
        }
    }
}