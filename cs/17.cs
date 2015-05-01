using System;
using System.Linq;
using System.Collections.Generic;

/* Project Euler #17
 * projecteuler.net/problem=17
 */
class E17 {

    private static String BritishString(int number) {
        var thousands = number / 1000;
        var hundredsTensAndOnes = number % 1000;
        var hundreds = hundredsTensAndOnes / 100; 
        var tensAndOnes = number % 100;
        var tens = tensAndOnes / 10;
        var ones = number % 10;
        return 
            OnesMap[thousands] + (thousands > 0 ? " thousand " : "") + 
            OnesMap[hundreds] + (hundreds > 0 ? " hundred" : "") +
            (hundreds > 0 && tensAndOnes > 0 ? " and " : "") +
            (tensAndOnes < 20 ? OnesMap[tensAndOnes] : TensMap[tens] + 
            (ones > 0 ? "-" : "") + OnesMap[ones]);
    }

    private static Dictionary<int, string> OnesMap = 
        new Dictionary<int, string>(){
        { 0, "" },
        { 1, "one" },
        { 2, "two" },
        { 3, "three" },
        { 4, "four" },
        { 5, "five" },
        { 6, "six" },
        { 7, "seven" },
        { 8, "eight" },
        { 9, "nine" },
        { 10, "ten" },
        { 11, "eleven" },
        { 12, "twelve" },
        { 13, "thirteen" },
        { 14, "fourteen" },
        { 15, "fifteen" },
        { 16, "sixteen" },
        { 17, "seventeen" },
        { 18, "eighteen" },
        { 19, "nineteen" },
    };

    private static Dictionary<int, string> TensMap = 
        new Dictionary<int, string>(){
        { 1, "ten" },
        { 2, "twenty" },
        { 3, "thirty" },
        { 4, "forty" },
        { 5, "fifty" },
        { 6, "sixty" },
        { 7, "seventy" },
        { 8, "eighty" },
        { 9, "ninety" },
        { 0, "" },
    };

    private static int LetterCount(string number) {
        return number.Where(x => Char.IsLetter(x)).Count();
    }

    public static void Main(string[] args) {
        /* Initial Tests 
        System.Console.WriteLine(BritishString(342));
        System.Console.WriteLine(BritishString(42));
        System.Console.WriteLine(BritishString(11));
        System.Console.WriteLine(BritishString(911));
        System.Console.WriteLine(BritishString(640));
        System.Console.WriteLine(BritishString(1000));
        System.Console.WriteLine(LetterCount(BritishString(342)));
        System.Console.WriteLine(LetterCount(BritishString(115)));
        */

        var sum = 0;
        for (var i = 1; i < 1001; i++) {
            sum += LetterCount(BritishString(i));
        }
        System.Console.WriteLine(sum);
    }
}
