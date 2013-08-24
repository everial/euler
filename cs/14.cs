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

    static class E14 {

        private static BigInteger CollatzStep(BigInteger n) {
            if (n == BigInteger.One) return BigInteger.One;
            return n % 2 == BigInteger.Zero ? n / 2 : 3 * n + BigInteger.One;
        }

        private static Func<BigInteger, BigInteger> CollatzLength() {
            return Utils.MemoizeFix<BigInteger, BigInteger>(
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
