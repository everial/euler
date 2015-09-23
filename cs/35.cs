using System;
using System.Collections.Generic;
using System.Linq;

/* "The number 197 is called a circular prime because all rotations of the
 * digits: 197, 971, and 719 are themselves prime. There are thirteen such
 * primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, and 97.
 *
 * How many circular primes are there below one million?"
 */
namespace Euler {
    class E35 {

        private static IEnumerable<String> Rotations(String source) {
            for (var i = 0; i < source.Length; i++) {
                yield return source.Substring(i, source.Length - i) + 
                    source.Substring(0, i);
            }
        }

        private static IEnumerable<int> Rotations(int source) {
            foreach (var rotation in Rotations(source.ToString()))
                yield return Int32.Parse(rotation);
        }

        private static bool IsCircular(int source) {
            return Rotations(source).All(Primes.IsPrime);
        }

        private const int _limit = 1000000;

        public static void Main(String[] args) {
            Console.WriteLine(Primes.IntStream()
                    .TakeWhile(p => p <= _limit)
                    .Where(IsCircular)
                    .Count());
        }
    }
}
