from pprint import pprint

class Solution:
    def lengthOfLongestSubstring(self, s: str) -> int:
        """
        # dumb n ** 2 version to start
        longest: int = 0
        for i in range(len(s)):
            seen: set[str] = set()
            for j in range(i, len(s)):
                if s[j] in seen:
                    break
                else:
                    seen.add(s[j])
            if len(seen) > longest:
                longest = len(seen)
        return longest
        """
        # idea: instead of set, keep map of characters and seen position
        # idea: when we see a repeat, check for new longest, then remove
        # idea: everything we saw after the repeated character
        seen: dict[str, int] = {}
        longest: int = 0
        for i, letter in enumerate(s):
            # print(i, letter)
            if letter in seen:
                #print(f'duplicate found, current: {seen}')
                if len(seen) > longest:
                    longest = len(seen)
                original = seen[letter]
                survivors = {}
                for s, position in seen.items():
                    if position > original:
                        survivors[s] = position
                survivors[letter] = i
                seen = survivors
                #print(f'survivors: {survivors}')
            else:
                seen[letter] = i
        #pprint(seen)
        if len(seen) > longest:
            longest = len(seen)
        return longest


def main():
    s = Solution()
    print(s.lengthOfLongestSubstring("dvdf"))


if __name__ == "__main__":
    main()

