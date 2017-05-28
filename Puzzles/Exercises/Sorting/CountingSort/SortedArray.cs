namespace Puzzles.Exercises.Sorting.CountingSort
{
    public class SortedArray
    {
        readonly int[] values;
        readonly int max;

        public SortedArray(int[] values, int max)
        {
            this.values = values;
            this.max = max;
        }

        public int[] SortedValues => SortValues();
        public int[] DescendingSortedValues => SortValuesInDescendingOrder();

        int[] SortValuesInDescendingOrder()
        {
            var counters = GetCounters();

            for (var i = 1; i < max + 1; i++)
            {
                counters[i] += counters[i - 1];
            }

            var sortedValues = new int[values.Length];

            for (var i = 0; i < values.Length; i++)
            {
                var currentValue = values[i];

                sortedValues[values.Length - counters[currentValue]] = currentValue;

                counters[currentValue]--;
            }

            return sortedValues;
        }

        int[] SortValues()
        {
            var counters = GetCounters();

            for (var i = 1; i < max + 1; i++)
            {
                counters[i] += counters[i - 1];
            }

            var sortedValues = new int[values.Length];
            
            for (var i = values.Length - 1; i >= 0; i--)
            {
                var currentValue = values[i];
                var counter = --counters[currentValue];

                sortedValues[counter] = currentValue;
                
            }

            return sortedValues;
        }

        int[] GetCounters()
        {
            var counters = new int[max + 1];

            for (var i = 0; i < values.Length; i++)
            {
                counters[values[i]]++;
            }

            return counters;
        }
    }
}