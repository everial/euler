using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Euler {

    /* "Using names.txt, a 46K text file containing over five thousand first
     * names, begin by sorting it into alphabetical order. Then working out the
     * alphabetical value for each name, multiply this value by its
     * alphabetical position in the list to obtain a name score.
     *
     * For example, when the list is sorted into alphabetical order, COLIN,
     * which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list.
     * So COLIN would obtain a score of 938 * 53 = 49714.
     *
     * What is the total of all the name scores in the file?"
     */
    public class E22 {

        private const string _default = "names.txt";
        private const string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const int _exampleIndex = 937;
        private const string _exampleName = "COLIN";
        private const int _exampleScore = 53;

        public static void Main(string[] args) {
            var names = new List<string>();
            string name;
            var source = args.Count() > 1 ? args[1] : _default;
            using (var file = new StreamReader(source)) {
                while ((name = file.ReadLine()) != null)
                    names.Add(name);
            }
            names.Sort();

            var letterScores = new Dictionary<char, int>();
            var start = 1;
            foreach (var letter in _alphabet)
                letterScores[letter] = start++;

            var total = BigInteger.Zero;
            for (var i = 0; i < names.Count; i++) {
                var score = names[i].Aggregate(0, 
                        (sum, letter)  => sum += letterScores[letter]);
                // Check the provided example.
                if (i == _exampleIndex) {
                    if (names[i] != _exampleName || score != _exampleScore) {
                        Console.WriteLine("Error: not matching PE example.");
                        return;
                    }
                }
                total += (i + 1) * score;
            }
            
            Console.WriteLine("The sum of all name scores is {0}.", total);
        }
    }
}
