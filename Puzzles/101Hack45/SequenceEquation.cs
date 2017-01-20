using System.Collections.Generic;
using System.Linq;

namespace Puzzles
{
    public struct SequenceEquation
    {
        readonly Element[] elements;

        public SequenceEquation(IEnumerable<int> p)
        {
            elements = p.Select((v, i) => new Element(i + 1, v)).ToArray();
        }

        public int[] Transforms => CalculateTransforms().ToArray();

        IEnumerable<int> CalculateTransforms()
        {
            for (var i = 1; i <= elements.Length; i++)
            {
                var pi = elements.First(e => e.Value == i);
                var ppi = elements.First(e => e.Value == pi.Number);

                yield return elements[ppi.Index].Number;
            }
        }
    }

    public struct Element
    {
        public Element(int number, int value)
        {
            Number = number;
            Value = value;
            Index = Number - 1;
        }

        public int Number { get; }
        public int Value { get; }
        public int Index { get; }
    }
}