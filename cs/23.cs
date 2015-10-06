using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler {

    /* from projecteuler.net/problem=23:
     * "A perfect number is a number for which the sum of its proper divisors
     * is exactly equal to the number. For example, the sum of the proper
     * divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is
     * a perfect number.
     *
     * A number n is called deficient if the sum of its proper divisors is less
     * than n and abundant if this sum exceeds n.
     *
     * As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the
     * smallest number that can be written as the sum of two abundant numbers
     * is 24. By mathematical analysis it can be shown that all integers
     * greater than 28123 can be written as the sum of two abundant numbers.
     * However, this upper limit cannot be reduced any further by analysis even
     * though it is known that the greatest number that cannot be expressed as
     * the sum of two abundant numbers is less than this limit.
     *
     * Find the sum of all the positive integers which cannot be written as the
     * sum of two abundant numbers."
     */
    public class E23 {

        private const int _limit = 28123;
        private const int _start = 12;
        private static IEnumerable<int> _abundants =
            AbundantNumbers().TakeWhile(n => n < _limit).ToList();
        private static SortedSet<int> _abundantSums = new SortedSet<int>();

        static E23() {
            foreach (var i in _abundants)
                foreach (var j in _abundants)
                    _abundantSums.Add(i + j);
        }

        private static bool IsAbundant(int n) {
            return n < Primes.Factor(n, proper:true).Sum();
        }

        private static IEnumerable<int> AbundantNumbers() {
            for (var i = _start; ; i++)
                if (IsAbundant(i))
                    yield return i;
        }

        private static IEnumerable<int> IntNaturals() {
            for (var i = 0; i < Int32.MaxValue; i++)
                yield return i;
        }

        // As there are only ~7000 abundant numbers below the given limit it's
        // easy enough to compute all the possible sums in range.
        private static bool IsSumOfTwoAbundants(int n) {
            return _abundantSums.Contains(n);
        }

        public static void Main(string[] args) {

            var sumNonAbundants = IntNaturals()
                .TakeWhile(n => n < _limit)
                .Where(m => !IsSumOfTwoAbundants(m))
                .Sum();

            Console.WriteLine("The sum of all positive integers which cannot"
                    + " be written as sum of two abundant numbers is {0}.",
                    sumNonAbundants);
        }
    }
}
