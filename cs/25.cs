using System;
using System.Collections.Generic;
using System.Numerics; // Compile with mcs -r:System.Numerics.dll main.cs

/* Project Euler.net #25
 *
 * What's the first Fibonacci number with 1000 decimal digits?
 *
 */

namespace Euler {

    class E25 {

        // TODO: pull this out - comes up lots in Euler problems.
        private static IEnumerable<BigInteger> Fibonacci() {
            var generator = Utils.MemoizeFix<int, BigInteger>(f => n => n > 2 ?
                    f(n - 1) + f(n - 2) : BigInteger.One);
            for (var i = 0; ; i++)
                yield return generator(i);
        }

        public static void Main(String[] args) {
            var i = 0;
            // foreach (var number in FibonacciSequence()) {
            foreach (var fib in Fibonacci()) {
                i++;
                if (fib.ToString().Length >= 1000) {
                    System.Console.WriteLine(i);
                    System.Console.WriteLine(fib);
                    break;
                }
            }
        }
    }
}
