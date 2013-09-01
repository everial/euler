using System;
using System.Linq;
using System.Collections.Generic;

namespace Euler {

    class E39 {

        private static IEnumerable<Tuple<int, int, int>> Triplets() {
            for (var c = 0; ; c++)
                for (var b = 0; b <= c; b++)
                    for (var a = 0; a <= b; a++)
                        yield return new Tuple<int, int, int>(a, b, c);
        }

        private static IEnumerable<Tuple<int, int, int>> RightTriangles() {
            foreach (var triple in Triplets()) {
                // Skip triplets that can't be triangles at all.
                if (triple.Item1 + triple.Item2 <= triple.Item3)
                    continue;
                if (triple.Item1 * triple.Item1 + triple.Item2 * triple.Item2 ==
                        triple.Item3 * triple.Item3)
                    yield return triple;
            }
        }

        private static int limit = 1000;

        public static void Main(String[] args) {
            var d = new Dictionary<int, int>();
            foreach (var triangle in RightTriangles().TakeWhile(x =>
                        x.Item1 + x.Item2 + x.Item3 <= limit)) {
                var perimeter = triangle.Item1 + triangle.Item2 + triangle.Item3;
                if (d.ContainsKey(perimeter))
                    d[perimeter] = d[perimeter] + 1;
                else
                    d[perimeter] = 1;
            }

            var most = 0;
            var perimeterWithMost = 0;
            foreach (var entry in d)
                if (entry.Value > most) {
                    most = entry.Value;
                    perimeterWithMost = entry.Key;
                }

            System.Console.WriteLine(perimeterWithMost);
        }
    }
}
