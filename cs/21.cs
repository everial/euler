using System;
using System.Collections.Generic;

/* "Let d(n) be defined as the sum of proper divisors of n (numbers less than n
 * which divide evenly into n). If d(a) = b and d(b) = a where a != b then
 * a and b are an amicable pair and each of a and b are called amicable
 * numbers.
 *
 * [example elided]
 *
 * Evaluate the sum of all the amicable numbers under 10000."
 */
namespace Euler {

    class E21 {

        private const int _limit = 10000;
        private static readonly Func<int, int> _sumDivisors = 
            Utils.Memoize<int, int>(SumDivisors);

        private static bool AreAmicable(int a, int b) {
            if (a == b)
                return false;
            return _sumDivisors(a) == b && _sumDivisors(b) == a;
        }

        private static int SumDivisors(int a) {
            var sum = 0;
            foreach (var factor in Primes.Factor(a, proper:true))
                sum += factor;
            return sum;
        }

        public static void Main(String[] args) {
            // Check ProjectEuler provided example.
            // Console.WriteLine(SumDivisors(220));
            // Console.WriteLine(SumDivisors(284));

            var amicableNumbers = new SortedSet<int>();

            for (var i = 2; i < _limit; i++)
                for (var j = i + 1; j < _limit; j++)
                    if (AreAmicable(i, j)) {
                        Console.WriteLine("i: " + i + " j: " + j);
                        amicableNumbers.Add(i);
                        amicableNumbers.Add(j);
                    }

            var sum = 0;
            foreach (var n in amicableNumbers)
                sum += n;

            Console.WriteLine("The sum of all amicable numbers under 10000 is "
                    + sum + ".");
        }
    }

}
