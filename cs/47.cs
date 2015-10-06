using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler {

    /* from projecteuler.net/problem=47
     * "The first two consecutive numbers to have two distinct prime factors
     * are:
     * 14 = 2 * 7
     * 15 = 3 * 5
     *
     * The first three consecutive numbers to have three distinct prime factors
     * are:
     * 644 = 2^2 * 7 * 23
     * 645 = 3 * 5 * 43
     * 646 = 2^2 * 17 * 19.
     *
     * Find the first four consecutive integers to have four distinct prime
     * factors. What is the smallest of these integers?
     */
    public class E47 {

        private const int _size = 4;

        private static int CountPrimeFactors(int n) {
            return Primes.PrimeFactor(n).Distinct().Count();
        }

        public static void Main(string[] args) {
            var streak = new int[_size];
            var count = 0;

            foreach (var i in Enumerable.Range(0, Int32.MaxValue)) {
                var hasFourFactors = CountFactors(i) == 4;
                if (hasFourFactors) {
                    streak[count++] = i;         
                    if (count == _size)
                        break;
                } else {
                    count = 0;
                    Array.Clear(streak, 0, _size);
                }
            }
            
            Console.WriteLine("The four consecutive integers to have four" +
                    " distinct prime factors are {0}, {1}, {2}, and {3}.",
                    streak[0], streak[1], streak[2], streak[3]);
        }
    }
}
