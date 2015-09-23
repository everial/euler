using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;

namespace Euler {

    public static class Utils {
        /*
         * Slick version courtesy of Eric Lippert.
         */
        public static Func<A, R> Memoize<A, R>(this Func<A, R> f) {
            var d = new Dictionary<A, R>();
            return a => {
                R r;
                if (!d.TryGetValue(a, out r)) {
                    r = f(a);
                    d.Add(a, r);
                }
                return r;
            };
        }

        /*
         * Courtesy of Wes Dyer.
         */
        public static Func<A, R> MemoizeFix<A, R>(this Func<Func<A, R>, 
                Func<A, R>> f) {
            Func<A, R> g = null;
            Func<A, R> h = null;
            g = a => f(h)(a);
            h = g.Memoize();
            return h;
        }

        /* Approximate the square root of the given BigInteger.
         * WARNING: breaks when the square root exceeds Double.MaxValue.
         * TODO: fix!
         */
        public static BigInteger SquareRoot(BigInteger value) {
            return new BigInteger(Math.Exp(BigInteger.Log(value) / 2));
        }

        /* Lazy, in-place generation of all permutations using Heap's algorithm.
         * See Wikipedia for details.
         * NOTE: the combination of in-place and lazy can be tricky!
         */
        public static IEnumerable<IList<T>> Permutations<T>(IList<T> source) {
            return Permute(source.Count(), source);
        }

        private static IEnumerable<IList<T>> Permute<T>(int n, 
                IList<T> source) {
            if (n == 1)
                yield return source;
            else {
                for (var i = 0; i < n - 1; i++) {
                    foreach (var permutation in Permute(n - 1, source))
                        yield return permutation;
                    if (n % 2 == 0) {
                        var temp = source[i];
                        source[i] = source[n - 1];
                        source[n - 1] = temp;
                    } else {
                        var temp = source[0];
                        source[0] = source[n - 1];
                        source[n - 1] = temp;
                    }
                }
                foreach (var permutation in Permute(n - 1, source))
                    yield return permutation;
            }
        }
    }
}
