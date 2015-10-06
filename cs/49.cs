using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler {

    /* from projecteuler.net/problem=49:
     * "The arithmetic sequence 1487, 4817, 8147, in which each of the terms
     * increases by 3330, is unusal in two ways: (i) each of the three terms
     * are prime, and (ii) each of the 4-digit numbers are permutations of one
     * another.
     *
     * There is no arithmetic sequence made up of 1, 2, or 3-digit primes
     * exhibiting this property but there is one other four digit increasing
     * sequence. 
     *
     * What 12-digit number do you form by concatenating the three terms in
     * this sequence?"
     */
    public class E49 {
        
        private const int _gap = 3330;
        private const int _lower = 999;
        private const int _upper = 10000;
        private const int _successors = 2;

        private static Func<int, bool> _isPrime = 
            Utils.Memoize<int, bool>(Primes.IsPrime);

        private static IEnumerable<int> IntPermutations(int n) {
            var digits = n.ToString().AsEnumerable().ToList();
            foreach (var p in Utils.Permutations(digits)) {
                yield return Int32.Parse(String.Join(String.Empty, p));
            }
        }

        private static bool HasNSuccessors(int start, IEnumerable<int> ints,
                int gap, int successors) {
            for (var i = 1; i < successors + 1; i++)
                if (!ints.Contains(start + i * gap))
                    return false;
            return true;
        }

        public static void Main(string[] args) {
            var triplets = new List<List<int>>();

            foreach (var prime in Primes.IntStream()
                    .SkipWhile(p => p < _lower)
                    .TakeWhile(p => p <= _upper - _successors * _gap)) {
                
                var primePermutations = IntPermutations(prime)
                    .Where(p => p > _lower && p < _upper)
                    .Distinct()
                    .Where(_isPrime);

                if (primePermutations.Count() >= 3 &&
                        HasNSuccessors(prime, primePermutations, _gap, 
                            _successors)) {
                    triplets.Add(new List<int>() { prime, prime + _gap,
                            prime + 2 * _gap });
                }
            }

            foreach (var triplet in triplets) {
                triplet.Sort();
                Console.WriteLine("Triplet of: {0}, {1}, {2}.",
                        triplet[0], triplet[1], triplet[2]);
            }
        }
    }
}
