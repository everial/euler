"""
Write a function to find the longest common prefix string amongst an array of strings.

If there is no common prefix, return an empty string "".

 

Example 1:

Input: strs = ["flower","flow","flight"]
Output: "fl"
Example 2:

Input: strs = ["dog","racecar","car"]
Output: ""
Explanation: There is no common prefix among the input strings.
 

Constraints:

1 <= strs.length <= 200
0 <= strs[i].length <= 200
strs[i] consists of only lowercase English letters if it is non-empty.
"""
class Solution:
    _max_length: int = 200
    def longestCommonPrefix(self, strs: List[str]) -> str:
        common_prefix: str = ""
        for i in range(self._max_length):
            if len(strs[0]) <= i:
                return common_prefix
            candidate = strs[0][i]
            for s in strs:
                if len(s) <= i:
                    return common_prefix
                if s[i] != candidate:
                    return common_prefix
            # TODO: stringbuilder/keep as list to avoid quadratic string copying
            common_prefix += candidate
        return common_prefix
