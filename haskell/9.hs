-- load in ghci
triplets = [[a, b, c] | c <- [1..500], b <- [1..c],
                        a <- [1..b], a + b + c == 1000, a^2 + b^2 == c^2]
answer = product (take 1 triplets !! 0)
