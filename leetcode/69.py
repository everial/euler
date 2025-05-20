"""
Given a non-negative integer x, return the square root of x rounded down to the nearest integer. The returned integer should be non-negative as well.

You must not use any built-in exponent function or operator.

For example, do not use pow(x, 0.5) in c++ or x ** 0.5 in python.
 

Example 1:

Input: x = 4
Output: 2
Explanation: The square root of 4 is 2, so we return 2.
Example 2:

Input: x = 8
Output: 2
Explanation: The square root of 8 is 2.82842..., and since we round it down to the nearest integer, 2 is returned.
 

Constraints:

0 <= x <= 231 - 1
"""

class Solution:
    def mySqrt(self, x: int) -> int:
        # special case the base cases
        if x == 0:
            return 0
        if x == 1:
            return 1
            """ 1082 ms
        candidate: int = 1
        for i in range(1, x):
            if i * i > x:
                return candidate
            candidate = i
        # perfect squares fall out
        return candidate
        """
        # linear with starting estimate - maybe too close to power?
        # 4365 -> 4 -> 2 -> 10
        as_str = str(x)
        half_magnitude: int = len(as_str) // 2
        start: int = int('1' + '0' * (half_magnitude - 1))
        candidate: int = start
        for i in range(start, x):
            if i * i > x:
                return candidate
            candidate = i  
        # perfect squares fall out
        return candidate
        """ 
        #binary search
        lower: int = 1
        upper: int = x // 2
        candidate: int = (lower + upper) // 2
        while True:
            squared = candidate * candidate
            if squared == x:
                return candidate
            if squared > x:
                upper = candidate
        """

        """ don't iterate from half since as x -> inf, sqrt x closer to 0
        candidate: int = x // 2
        for i in range(candidate, 0, -1):
            if i * i <= x:
                return i
        # error
        return candidate
        """

        
