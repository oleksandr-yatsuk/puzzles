namespace Puzzles
{
    public struct HackonacciNumber
    {
        public HackonacciNumber(int n)
        {
            Value = CalculateValue(n);
        }

        public long Value { get; }
        public char Symbol => (Value & 1) == 0 ? 'X' : 'Y';

        static long CalculateValue(int number)
        {
            if (number <= 3)
                return number;

            long a = 1, b = 2, c = 3, d = 0;

            for (var i = 0; i < number - 3; i++)
            {
                d = a + 2 * b + 3 * c;
                a = b;
                b = c;
                c = d;
            }

            return d;
        }
    }
}