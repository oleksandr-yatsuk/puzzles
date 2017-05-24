using System.Linq;
using Puzzles.Common.Extensions;

namespace Puzzles.Exercises.Strings.PerfectSubsequences
{
    public class Game
    {
        readonly string[] sequences;
        readonly long maximumLength;
        readonly long modulus;

        public Game(string[] sequences, long maximumLength, long modulus)
        {
            this.sequences = sequences;
            this.maximumLength = maximumLength;
            this.modulus = modulus;
        }

        public long[] NumberOfPerfectSequences => CalculateNumbersOfPerfectSubsequences();

        long[] CalculateNumbersOfPerfectSubsequences()
        {
            var factorials = new FactorialsSet(maximumLength, modulus);
            var inverseFactorials = new InverseFactorialsSet(factorials);

            return sequences
                    .Select(sequence => CalculateNumberOfPerfectSubsequences(sequence, factorials, inverseFactorials))
                    .ToArray();
        }

        static long CalculateNumberOfPerfectSubsequences(string sequence, FactorialsSet factorials, InverseFactorialsSet inverseFactorials)
        {
            var modulus = factorials.Modulus;
            var counts = new long[4]; // {a, b, c, d}

            sequence.ForEach(letter => counts[letter - 'a']++);

            var ab = factorials.Get(counts[0] + counts[1]) * 
                (inverseFactorials.Get(counts[0]) * inverseFactorials.Get(counts[1]) % modulus) % modulus;
            var cd = factorials.Get(counts[2] + counts[3]) * 
                (inverseFactorials.Get(counts[2]) * inverseFactorials.Get(counts[3]) % modulus) % modulus;

            return (ab * cd + modulus - 1) % modulus;
        }
    }
}