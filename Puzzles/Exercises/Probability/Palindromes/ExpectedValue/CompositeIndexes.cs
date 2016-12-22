using Puzzles.Common.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace Puzzles.Exercises.Probability.Palindromes.ExpectedValue
{
    public class CompositeIndexes : IEnumerable<int[]>
    {
        readonly int upperBound;
        readonly int length;

        public CompositeIndexes(int upperBound, int length)
        {
            this.upperBound = upperBound;
            this.length = length;
        }

        public IEnumerator<int[]> GetEnumerator()
        {
            var indexes = new int[length];

            while (true)
            {
                yield return indexes.Copy();
                
                for (var i = 0;;i++)
                {
                    if (i == length) yield break;
                    if (++indexes[i] < upperBound) break;

                    indexes[i] = 0;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}