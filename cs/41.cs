using System;
using System.Collections.Generic;
using System.Linq;

/* "We shall say that an n-digit number is pandigital if it makes use of all
 * the digits 1 to n exactly once. For example, 2143 is a 4-digit pandigital
 * and is also prime.
 *
 * What is the largest n-digit pandigital prime?"
 */
namespace Euler {

    class E41 {

        private static readonly IList<char> _digits =
            new List<char>(new char[] { '1', '2', '3', '4', '5', '6', '7',
                    '8', '9' });

        private static IEnumerable<int> Pandigitals() {
            for (var i = 1; i <= _digits.Count(); i++) {
                foreach (var permutation in 
                        Utils.Permutations(_digits.Take(i).ToList()))
                    yield return Int32.Parse(
                            String.Join(String.Empty, permutation));
            }
        }

        private const int _limit = 987654321;

        public static void Main(String[] args) {
            // Lots more primes than pandigitals, so generate pandigitals 
            // and check them for primality.
            Console.WriteLine(Pandigitals()
                    .TakeWhile(p => p <= _limit)
                    .Where(Primes.IsPrime)
                    .Max());
        }
    }
}
