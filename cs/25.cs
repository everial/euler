using System;
using System.Collections.Generic;
using System.Numerics; // Compile with mcs -r:System.Numerics.dll main.cs

/* Project Euler.net #25
 *
 * What's the first Fibonacci number with 1000 decimal digits?
 *
 */

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

class E25 {

    // TODO: pull this out - comes up lots in Euler problems.
    private static Func<int, BigInteger> Fibonacci() {
        // return Memoizer.Memoize<int, BigInteger>(naiveFibonacci); 
        // From Wes Dyer... don't totally understand how this works quite yet.
        return Memoizer.MemoizeFix<int, BigInteger>(f => n => n > 2 ?
                f(n - 1) + f(n - 2) : BigInteger.One);
    }

    private static BigInteger naiveFibonacci(int n) {
        if (n == 1 || n == 2)
            return BigInteger.One;
        return naiveFibonacci(n - 1) + naiveFibonacci(n - 2);
    }

    private static IEnumerable<BigInteger> FibonacciSequence() {
        Func<int, BigInteger> generator = Fibonacci();
        for (var i = 1; ; i++)
            yield return generator(i);
    }

    public static void Main(string[] args) {
        var i = 0;
        foreach (var number in FibonacciSequence()) {
            i++;
            if (number.ToString().Length >= 1000) {
                System.Console.WriteLine(i);
                System.Console.WriteLine(number);
                break;
            }
        }
    }
}
