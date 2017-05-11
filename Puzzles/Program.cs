using System;
using Puzzles.Exercises.Strings;

namespace Puzzles
{
    class Program
    {
        public static void Main()
        {

            Console.WriteLine(CountSubs("abcd"));
            Console.WriteLine(CountSubs("cad"));
            Console.WriteLine(CountSubs("dcc"));

            Console.ReadKey();
        }

        static long CountSubs(string s)
        {
            long a = 0;
            long b = 0;
            long c = 0;
            long d = 0;

            foreach (var l in s)
            {
                switch (l)
                {
                    case 'a': a++; break;
                    case 'b': b++; break;
                    case 'c': c++; break;
                    default: d++; break;
                }
            }

            var m1 = a < b ? a : b;
            var m2 = c < d ? c : d;

            long m = 7 + 1000000000;

            long ab = 0;
            long cd = 0;

            for (long i = 1; i <= m1; i++)
            {
                ab = (ab % m + (BinomialCoefficient(a, i, m) * BinomialCoefficient(b, i, m)) % m) % m;
            }

            for (long i = 1; i <= m2; i++)
            {
                cd = (cd % m + (BinomialCoefficient(c, i, m) * BinomialCoefficient(d, i, m)) % m) % m;
            }

            return (((ab + 1) % m * (cd + 1) % m) % m - 1) % m;
        }

        static long Factorial(long n, long mod)
        {
            long factorial = 1;

            for (long i = 2; i <= n; i++)
            {
                factorial = ((factorial % mod) * (i % mod)) % mod;
            }

            return factorial;
        }

        static long BinomialCoefficient(long n, long k, long mod)
        {
            if (n < k || (n == k && k == 0)) return 0;

            long top = 1;

            for (var i = n; i >= n - k + 1; i--)
            {
                top = ((top % mod) * i % mod) % mod;
            }

            return top / Factorial(k, mod);
        }
    }
}
