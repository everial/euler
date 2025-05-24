"""
Given a string s consisting of words and spaces, return the length of the last word in the string.

A word is a maximal substring consisting of non-space characters only.

 

Example 1:

Input: s = "Hello World"
Output: 5
Explanation: The last word is "World" with length 5.
Example 2:

Input: s = "   fly me   to   the moon  "
Output: 4
Explanation: The last word is "moon" with length 4.
Example 3:

Input: s = "luffy is still joyboy"
Output: 6
Explanation: The last word is "joyboy" with length 6.
 

Constraints:

1 <= s.length <= 104
s consists of only English letters and spaces ' '.
There will be at least one word in s.
"""


_separator = ' '

class Solution:

    def lengthOfLastWord(self, s: str) -> int:
        pieces = s.split(self._separator)
        for i in range(-1, -len(pieces), -1):
            if pieces[i]:
                return len(pieces[i])
        return len(pieces[0]) # falls out to special case for single string


        """
        return len(s) - (s.rfind(" ") + 1) # doesn't work due to multiple trailing spaces
        """

        """
        # According to leetcode this is at parity (memory and speed-wise) with the split
        length: int = 0
        counting: bool = False
        for i in range(-1, -(len(s) + 1), -1):
            # have we found anything yet?
            if not counting and s[i] != _separator:
                counting = True
                length = 1
            elif not counting and s[i] == _separator:
                continue
            elif counting and s[i] == _separator:
                return length
            else: # counting and s[i] != _separator
                length += 1

        return length
        """

