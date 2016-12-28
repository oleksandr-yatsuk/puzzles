namespace Puzzles.Exercises.Hackonacci
{
    public struct HackonacciNumber
    {
        public HackonacciNumber(int n)
        {
            Value = CalculateValue(n);
        }

        public long Value { get; }

        static long CalculateValue(int number)
        {
            if (number <= 3)
                return number;

            long a = 1, b = 2, c = 3, d = 0;

            for (var i = 0; i < number - 3; i++)
            {
                d = 3*a + 2*b + c;
                a = b;
                b = c;
                c = d;
            }

            return d;
        }
    }
}