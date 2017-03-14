using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Exercises.Sorting.HeapSort
{
    public class Heap<T> : IEquatable<Heap<T>>, IEnumerable<T>
    {
        readonly List<T> values = new List<T>();

        public Heap(IEnumerable<T> values)
        {
            this.values.AddRange(values);
        }

        public int Parent(int i) => ((i + 1) >> 1) - 1;
        public int Left(int i) => ((i + 1) << 1) - 1;
        public int Right(int i) => (i + 1) << 1;

        public int Size => values.Count;

        public T Get(int i) => values[i];
        public T GetParent(int i) => values[Parent(i)];
        public T GetLeft(int i) => values[Left(i)];
        public T GetRight(int i) => values[Right(i)];

        public bool HasLeft(int i) => Left(i) < Size;
        public bool HasRight(int i) => Right(i) < Size;

        public bool IsRoot(int i) => i == 0;
        public bool IsLeaf(int i) => !HasLeft(i) && !HasRight(i);

        public void Exchange(int i, int j)
        {
            var temp = values[i];

            values[i] = values[j];
            values[j] = temp;
        }

        public bool Equals(Heap<T> other)
        {
            return other != null && (values == other.values || ValuesEqual(other.values));
        }

        bool ValuesEqual(IReadOnlyList<T> otherValues)
        {
            if (values.Count != otherValues.Count)
                return false;

            return !values.Where((v, i) => !v.Equals(otherValues[i])).Any();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return values.GetEnumerator();
        }
    }
}