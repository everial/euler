using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;

/* Project Euler #14
 *
 * What's the longest Collatz chain starting with a number under one million?
 *
 */
namespace Euler {

    static class Memoizer {

        // TODO: pull this out.
        // Slick version courtesy of Eric Lippert.
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

        public static Func<A, R> MemoizeFix<A, R>(this Func<Func<A, R>, 
                Func<A, R>> f) {
            Func<A, R> g = null;
            Func<A, R> h = null;
            g = a => f(h)(a);
            h = Memoizer.Memoize(g);
            return h;
        }
    }

    static class E14 {

        private static BigInteger CollatzStep(BigInteger n) {
            if (n == BigInteger.One) return BigInteger.One;
            return n % 2 == BigInteger.Zero ? n / 2 : 3 * n + BigInteger.One;
        }

        private static Func<BigInteger, BigInteger> CollatzLength() {
            return Memoizer.MemoizeFix<BigInteger, BigInteger>(
                    f => n => n == 1 ? 1 : 1 + f(CollatzStep(n)));
        }

        private static IEnumerable<BigInteger> CollatzLengths() {
            var generator = CollatzLength();
            for (var i = 1; ; i++)
                yield return generator(i);
        }

        private const int Limit = 1000000;

        public static void Main(String[] args) {
            var longest = 1;
            var length = BigInteger.One;
            int i = 1;
            foreach (var chain in CollatzLengths()) {
                if (chain > length) {
                    length = chain;
                    longest = i;
                }
                i++;
                if (i >= 1000000)
                    break;
            }
            
            System.Console.WriteLine("{0} has the longest Collatz chain" +
                    " under {1}.", longest, Limit);
        }
    }
}
