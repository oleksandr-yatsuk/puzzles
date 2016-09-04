using System.Linq;

namespace Puzzles.Exercises.Probability.BirthdayGift
{
    public class PhoneBuyer
    {
        public double CalculatePriceGreedy(long[] numbersOnBalls)
        {
            var maxNumberOfAllSums = (long)1 << numbersOnBalls.Length;

            long sum = 0;

            for (long i = 0; i < maxNumberOfAllSums; i++)
            {
                sum += CalculateOneSum(numbersOnBalls, i);
            }

            return (double)sum / maxNumberOfAllSums;
        }

        public double CalculatePrice(long[] numbersOnBalls)
        {
            var sum = numbersOnBalls.Sum();
            var half = sum >> 1; // Indicator random variables
            var reminder = (sum & 1) == 0 ? 0 : 0.5;

            return half + reminder;
        }

        static long CalculateOneSum(long[] numbersOnBalls, long indexes)
        {
            long sum = 0;

            for (var j = 0; j < numbersOnBalls.Length; j++)
            {
                sum += numbersOnBalls[j] * ((indexes >> j) & 1);
            }

            return sum;
        }
    }
}