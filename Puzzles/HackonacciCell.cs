using System;

namespace Puzzles
{
    public class HackonacciCell : IEquatable<HackonacciCell>
    {
        readonly int id;
        char symbol;

        public HackonacciCell(int i, int j)
        {
            id = i*j;
        }

        public char Symbol => GetSymbol();

        public bool Equals(HackonacciCell other)
        {
            return other != null && id == other.id;
        }

        public override int GetHashCode()
        {
            return id;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as HackonacciCell);
        }

        char GetSymbol()
        {
            return symbol == default(char) 
                ? (symbol = new HackonacciNumber(id * id).Symbol) 
                : symbol;
        }
    }
}