using System;
using System.Collections.Generic;
using System.Numerics;

/* Project Euler #12
 * 
 * Let the n^th triangle number be sum(1..n). What's the first triangle number
 * to have over five hundred divisors?
 */

class E12 {

    private static Func<int, BigInteger> Triangle() {
        return utils.MemoizeFix<int, BigInteger>(f => n => n == 1 ?
                1 : f(n - 1));

    private static IEnumerable<BigInteger> TriangleSequence() {
        Func<int, BigInteger> generator = Triangle();
        for (var i = 1; ; i++)
            yield return Triangle(n);
    }

    private static IEnumerable<BigInteger> Factor(BigInteger number) {
        
        
    }

    private static IEnumerable<IEnumerable<A>> PowerSet(IEnumerable<A> items) {

    }

    public static void Main(string[] args) {
        foreach (var number in TriangleSequence()) {
            var divisors = ;
            if (divisors.Length > 500)
                System.Console.WriteLine(number);
        }
    }
}
