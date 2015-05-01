open System.Collections.Generic

let memoize f =
    let cache = new Dictionary<_, _>()
    (fun a -> match cache.TryGetValue(a) with
                | true, r -> r
                | _       -> let v = f a
                             cache.Add(a, v)
                             v)

