using System.Collections.Generic;
using System.Linq;
using System;

/* ProjectEuler.net #40
 *
 * Champernowne's Constant is the irrational number formed by concatenating
 * the positive integers beginning with .1:
 * .123456789101112...
 *
 * If d_n represents the nth (1-indexed digit), what is
 * d_1 * d_10 * d_100 * d_1000 * d_10000 * d_100000 * d_1000000
 * ?
 */

class E40 { 

    private static IEnumerable<char> ChampernowneDigits() {
        for (var i = 1; ; i++)
            foreach (var digit in i.ToString())
                yield return digit;
    }

    public static int Main(string[] args) {
        // Condense?
        var digits = ChampernowneDigits();
        IEnumerable<int> places = from number in Enumerable.Range(0, 7) select
            (int) (Math.Pow(10, number) - 1);
        var selected = from place in places select 
            Int32.Parse(digits.ElementAt(place).ToString());
        System.Console.WriteLine(
                selected.Aggregate(1, (current, term) => current * term));
        return 0;
    }

}
