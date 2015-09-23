using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

/* Project Euler #12
 * 
 * Let the n^th triangle number be sum(1..n). What's the first triangle number
 * to have over five hundred divisors?
 */

namespace Euler {

    class E12 {

        private static IEnumerable<BigInteger> Triangles() {
            var current = BigInteger.Zero;
            for (var i = BigInteger.One; ; i++) {
                current = current + i;
                yield return current;
            }
        }

        private const int _count = 500;

        public static void Main(string[] args) {
            foreach (var triangle in Triangles()) {
                if (Primes.CountFactors(triangle) > _count) {
                    Console.WriteLine(triangle);
                    return;
                }
            }
        }
    }
}
