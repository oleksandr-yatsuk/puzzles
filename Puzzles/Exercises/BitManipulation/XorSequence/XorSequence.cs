namespace Puzzles.Exercises.BitManipulation.XorSequence
{
    public class XorSequence
    {
        public long XorSubsequence(long l, long r)
        {
            if (IsOdd(l))
            {
                var evenNumbers = XorBetween((l + 1) >> 1, r >> 1) << 1;

                return IsOdd(r) 
                    ? evenNumbers ^ XorTill(r)
                    : evenNumbers;
            }

            return XorTill(l) ^ XorSubsequence(l + 1, r);
        }

        static long XorBetween(long n, long m)
        {
            var xorM = XorTill(m);

            return n > 0
                ? xorM ^ XorTill(n - 1)
                : xorM;
        }

        static long XorTill(long n)
        {
            var rightOperand = (n & 1) == 1 ? 1 : n;

            return ((n >> 1) & 1) ^ rightOperand;
        }

        static bool IsOdd(long number)
        {
            return (number & 1) == 1;
        }
    }
}