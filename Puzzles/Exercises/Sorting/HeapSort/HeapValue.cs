namespace Puzzles.Exercises.Sorting.HeapSort
{
    public struct HeapValue<T>
    {
        public HeapValue(int key, T value)
        {
            Key = key;
            Value = value;
        }

        public int Key { get; }
        public T Value { get; }

        public HeapValue<T> WithNewKey(int key)
        {
            return new HeapValue<T>(key, Value);
        }

        public static bool operator <(HeapValue<T> current, HeapValue<T> value)
        {
            return current.Key < value.Key;
        }

        public static bool operator >(HeapValue<T> current, HeapValue<T> value)
        {
            return current.Key > value.Key;
        }
    }
}