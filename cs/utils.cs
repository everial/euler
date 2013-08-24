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
    }
}
