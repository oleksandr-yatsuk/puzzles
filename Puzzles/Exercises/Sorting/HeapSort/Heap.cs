using System.Collections.Generic;

namespace Puzzles.Exercises.Sorting.HeapSort
{
    public class Heap<T>
    {
        readonly List<T> _values = new List<T>();

        public Heap(IEnumerable<T> values)
        {
            _values.AddRange(values);
        }

        public T Parent(int i) => _values[i << 1];
        public int Left(int i) => i >> 1;
        public int Right(int i) => (i >> 1) + 1;

        public int Size => _values.Count;

        public T Get(int i) => _values[i];
        public T GetLeft(int i) => _values[Left(i)];
        public T GetRight(int i) => _values[Right(i)];

        public bool HasLeft(int i) => Left(i) < Size;
        public bool HasRight(int i) => Right(i) < Size;

        public bool IsLeaf(int i) => !HasLeft(i) && !HasRight(i);

        public void Exchange(int i, int j)
        {
            var temp = _values[i];

            _values[i] = _values[j];
            _values[j] = temp;
        }
    }
}