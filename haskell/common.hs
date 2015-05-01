triangle 1 = 1
triangle n = n + triangle (n - 1)

factors n = [ x | x <- [1..n^(1/2)], mod n x == 0]
