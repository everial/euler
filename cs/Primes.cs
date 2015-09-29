using System;
using System.Collections.Generic;
using System.Numerics;
// TODO: get this from NuGet.
// using System.Collections.Immutable;
using System.Linq;

namespace Euler {

    public static class Primes {

        public static readonly BigInteger Two = new BigInteger(2);

        public static IEnumerable<BigInteger> Stream() {
            var primes = new List<BigInteger>();

            for (var candidate = new BigInteger(2); ;
                    candidate += BigInteger.One) {
                var factorFound = false;
                foreach (var prime in primes) {
                    factorFound = 
                        BigInteger.Remainder(candidate, prime) == 
                        BigInteger.Zero;
                    if (factorFound)
                        break;
                }
                if (!factorFound) {
                    primes.Add(candidate);
                    yield return candidate;
                }
            }
        }

        /* Returns a smallest-to-largest list of the given number's prime
         * factors. Returns an empty list for inputs smaller than 2.
         * TODO: use ImmutableList.
         * TODO: memoize?
         */
        public static IList<BigInteger> PrimeFactor(BigInteger factorMe) {
            var factors = new List<BigInteger>();
            var candidates = Primes.Stream().TakeWhile(p => p <= 
                    BigInteger.Max(7, Utils.SquareRoot(factorMe)));
            if (!candidates.Any())
                return factors;
            
            var remains = factorMe;
            BigInteger remainder;
            while (remains != BigInteger.One) {
                var factorFound = false;
                foreach (var c in candidates) {
                    var result = BigInteger.DivRem(remains, c, out remainder);
                    if (remainder == BigInteger.Zero) {
                        remains = result;
                        factors.Add(c);
                        factorFound = true;
                        break;
                    }
                }
                // Checked all the possibilities up to square root so what
                // remains must be prime.
                if (!factorFound && remains > candidates.Last()) { 
                    factors.Add(remains);
                    break;
                }
            }
            return factors;
        }

        public static bool IsPrime(this BigInteger number) {
            if (number < Two)
                return false;

            var candidates = 
                Primes.Stream().TakeWhile(p => p <= Utils.SquareRoot(number));
            foreach (var prime in candidates)
                if (BigInteger.Remainder(number, prime) == BigInteger.Zero)
                    return false;
            return true;
        }

        public static int CountFactors(BigInteger factorMe) {
            var primeFactors = PrimeFactor(factorMe);
            if (!primeFactors.Any())
                return 0;

            var counts = 
                primeFactors.GroupBy(x => x).Select(x => x.Count() + 1);
            return counts.Count() == 1
                ? counts.First()
                : counts.Aggregate((x, y) => x * y);
        }

        /* Returns a smallest-to-largest list of the given number's factors.
         * TODO: see TODOs on PrimeFactor.
         */
        public static IList<BigInteger> Factor(BigInteger factorMe) {
            var primeFactors = PrimeFactor(factorMe);

            var factors = new List<BigInteger>();
            factors.Add(BigInteger.One);

            foreach (var group in primeFactors.GroupBy(x => x)) {

            }

            return factors;
        }

#region int
/* Ideally we'd be able to shift between BigIntegers and machine integers
 * as needed. For now we're keeping separate int versions of the methods 
 * for speed. See the corresponding BigInteger methods for documentation.
 */
        public static bool IsPrime(int number) {
            if (number < 2)
                return false;

            var candidates = Primes.IntStream().TakeWhile(
                    p => p <= Math.Sqrt(number));
            foreach (var prime in candidates)
                if (number % prime == 0)
                    return false;
            return true;
        }
        
        public static IEnumerable<int> IntStream() {
            var primes = new List<int>();

            for (var candidate = 2; ; candidate++) {
                var factorFound = false;
                foreach (var prime in primes) {
                    factorFound = candidate % prime == 0;
                    if (factorFound)
                        break;
                }
                if (!factorFound) {
                    primes.Add(candidate);
                    yield return candidate;
                }
            }
        }

        public static IList<int> PrimeFactor(int factorMe) {
            var factors = new List<int>();
            var candidates = Primes.IntStream().TakeWhile(p => 
                    p <= Math.Sqrt(factorMe));
            if (!candidates.Any())
                return factors;
            
            var remains = factorMe;
            int remainder;
            while (remains != 1) {
                var factorFound = false;
                foreach (var c in candidates) {
                    var result = Math.DivRem(remains, c, out remainder);
                    if (remainder == 0) {
                        remains = result;
                        factors.Add(c);
                        factorFound = true;
                        break;
                    }
                }
                // Checked all the possibilities up to square root so what
                // remains must be prime.
                if (!factorFound && remains > candidates.Last()) { 
                    factors.Add(remains);
                    break;
                }
            }
            return factors;
        }

        // TODO: test speed against iterative version. 
        public static IEnumerable<int> Factor(int factorMe, 
                bool proper = false) {
            var factors = new SortedSet<int>();
            foreach (var set in Utils.PowerSet(PrimeFactor(factorMe))) {
                var product = 1;
                foreach (var factor in set)
                    product *= factor;
                factors.Add(product);
            }
            if (proper)
                factors.Remove(factorMe);
            
            return factors;
        }
#endregion 

    }
}
